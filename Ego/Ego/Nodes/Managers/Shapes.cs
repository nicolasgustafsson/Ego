using Rendering;
using Rendering.Materials;
using VulkanApi;

namespace Ego;

//Immediate mode shapes drawing!
[Node(AllowAddingToScene = false)]
public partial class Shapes : Node
{
    public struct PointDrawCommand
    {
        public Vector3 Position;
        public Vector4 Color;
        public float Size;
    }
    public struct LineDrawCommand
    {
        public Vector3 Start;
        public Vector3 End;
        public Vector4 Color;
        public float Thickness;
    }
    
    private struct LineVertex
    {
        public Vector3 Position;
        public float Dummy;
        
        public LineVertex(float X, float Y, float Z)
        {
            Position.X = X;
            Position.Y = Y;
            Position.Z = Z;
        }
    }

    
    private struct Garbage
    {
        public float PieceOfGarbage;
    }
    
    private List<LineDrawCommand> DrawCommands = new();
    private List<PointDrawCommand> PointDrawCommands = new();

    private MeshData SquareMesh = null!;
    private Material LineMaterial = null!;
    private Material PointMaterial = null!;
    private GpuBuffer<Garbage> GarbageBuffer = null!;

    public override void Start()
    {
        base.Start();
        
        List<LineVertex> vertices = new(){new(0f, 0f, 0f), new(1f, 0f, 0f), new(1f, 1f, 0f), new(0f, 1f, 0f)};
        List<uint> indices = new() {0, 2, 3, 2, 0, 1 };

        GarbageBuffer = new(GpuBufferType.Uniform, GpuBufferTransferType.Direct);
        
        SquareMesh = new MeshData("Line", (new[]{new GeoSurface(){StartIndex = 0, Count = 6}}).ToList(), new MeshBuffers<LineVertex>(RendererApi.Renderer, MemoryAllocator.GlobalAllocator, indices, vertices));
        LineMaterial = new Material("Shaders/line.slang", GarbageBuffer, this);
        PointMaterial = new Material("Shaders/point.slang", GarbageBuffer, this);
    }

    public void DrawLine(Vector3 aStart, Vector3 aEnd, Vector4 aColor, float aThickness)
    {
        DrawCommands.Add(new() { Start = aStart, End = aEnd, Color = aColor, Thickness = aThickness});
    }
    
    public void DrawPoint(Vector3 aPosition, Vector4 aColor, float aSize) 
    {
        PointDrawCommands.Add(new() { Position = aPosition, Color = aColor, Size = aSize});
    }

    protected override void Update()
    {
        
        foreach(var command in DrawCommands)
        {
            Matrix4x4 matrix = new();

            ClippedLine line = new() { Start = command.Start, End = command.End };//GetClippedLine(command.Start, command.End);
            
            matrix[0,0] = line.Start.X;
            matrix[0,1] = line.Start.Y;
            matrix[0,2] = line.Start.Z;
            matrix[1,0] = line.End.X;
            matrix[1,1] = line.End.Y;
            matrix[1,2] = line.End.Z;
            matrix[2,0] = command.Thickness;
            matrix[3,0] = command.Color.X;
            matrix[3,1] = command.Color.Y;
            matrix[3,2] = command.Color.Z;
            matrix[3,3] = command.Color.W;
            
            RendererApi.RenderData.MeshRenders.Add(new() { MyMeshData = SquareMesh, Material = LineMaterial, WorldMatrix = matrix });
        }
        
        foreach(var command in PointDrawCommands)
        {
            Matrix4x4 matrix = new();

            matrix[0,0] = command.Position.X;
            matrix[0,1] = command.Position.Y;
            matrix[0,2] = command.Position.Z;
            matrix[2,0] = command.Size;
            matrix[3,0] = command.Color.X;
            matrix[3,1] = command.Color.Y;
            matrix[3,2] = command.Color.Z;
            matrix[3,3] = command.Color.W;
            
            RendererApi.RenderData.MeshRenders.Add(new() { MyMeshData = SquareMesh, Material = PointMaterial, WorldMatrix = matrix });
        }
        
        DrawCommands.Clear();
        PointDrawCommands.Clear();
    }
    
    
    private struct ClippedLine
    {
        public Vector3 Start;
        public Vector3 End;
    }
    
    private ClippedLine GetClippedLine2(Vector3 aStart, Vector3 aEnd, Vector3 aCameraPosition, Vector3 aCameraLookDirection)
    {
        float startDistance = Vector3.Dot(aStart - aCameraPosition, aCameraLookDirection);
        float endDistance = Vector3.Dot(aEnd - aCameraPosition, aCameraLookDirection);

        return new();
    }
    
    private ClippedLine GetClippedLine(Vector3 aStart, Vector3 aEnd)
    {
                                                        //Not thread safe - should do something about it
        Plane[] planes = Plane.ExtractPlanesFromFrustum(RendererApi.Renderer.SceneData.ViewProjection);


        ClippedLine line = new();
        
        int index = 0;

        List<Vector3> collisions = new();
        foreach(var plane in planes)
        {
            Vector3? result = LinePlaneIntersection(aStart, aEnd, plane.Normal, plane.Position);//plane.IntersectLine(aStart, aEnd);
            
            if (result != null)
            {
                collisions.Add(result.Value);
            }
            
            index++;
        }
        
        if (collisions.Count == 2)
        {
            float distanceToEnds = collisions.Min(vector3 => (line.End - vector3).LengthSquared());
            float distanceToStarts = collisions.Min(vector3 => (line.Start - vector3).LengthSquared());
            
            if (distanceToEnds < distanceToStarts)
            {
                line.End = collisions.MinBy(vector3 => (line.End - vector3).LengthSquared());
                line.Start = collisions.MaxBy(vector3 => (line.End - vector3).LengthSquared());
            }
            else
            {
                line.Start = collisions.MinBy(vector3 => (line.Start - vector3).LengthSquared());
                line.End = collisions.MaxBy(vector3 => (line.Start - vector3).LengthSquared());
            }
        }
        
        if (collisions.Count == 0)
        {
            line.Start = aStart;
            line.End = aEnd;
        }
        
        if (collisions.Count == 1)
        {
            bool startInFrustum = true;
            foreach(var plane in planes)
            {
                if (plane.DotNormal(aStart) > 0)
                {
                    startInFrustum = false;
                    break;
                }
            }
            
            if (startInFrustum)
            {
                line.Start = aStart;
                line.End = collisions[1];
            }
        }

        return line;
    }
    
    public static Vector3? LinePlaneIntersection(Vector3 linePoint, Vector3 lineVec, Vector3 planeNormal, Vector3 planePoint)
    {
        float length;
        float dotNumerator;
        float dotDenominator;
        Vector3 vector;

        //calculate the distance between the linePoint and the line-plane intersection point
        dotNumerator = Vector3.Dot((planePoint - linePoint), planeNormal);
        dotDenominator = Vector3.Dot(lineVec, planeNormal);

        if (dotDenominator != 0.0f)
        {
            length = dotNumerator / dotDenominator;

            vector = Vector3.Normalize(lineVec) * length;

            return linePoint + vector;
        }

        else
            return null;
    }
}
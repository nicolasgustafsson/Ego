using VulkanApi;

namespace Ego;

public static class ImageRegistry
{
    /*
     * The idea here is that we have a huuuuuuge descriptor of literally all the textures(except render textures), then index into it using descriptor indexing.
     * This way we don't need to bind textures for every material! This simplifies rendering and allows us to move towards a bindless model.
     */

    private static List<Image?> myImages = new();
    private static List<int> myFreeIndices = new();

    public static List<Image?> GetAllImages() => myImages;
    
    public static int AddImage(Image aImage)
    {
        int? freeImageIndex = GetFreeImageIndex();
        if (freeImageIndex != null)
        {
            myImages[freeImageIndex.Value] = aImage;
            return freeImageIndex.Value;
        }

        myImages.Add(aImage);
        return myImages.Count - 1;
    }
    
    private static int? GetFreeImageIndex()
    {
        if (myFreeIndices.Count == 0)
            return null;

        return myFreeIndices.First();
    }
    
    public static void RemoveImage(Image aImage)
    {
        myImages[aImage.Index!.Value] = null;

        myFreeIndices.Add(aImage.Index!.Value);
    }
}
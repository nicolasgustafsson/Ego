using Vortice.ShaderCompiler;

namespace Graphics;



public unsafe class DescriptorWriter
{
    private struct DescriptorWrite(VkWriteDescriptorSet write, DescriptorWrite.WriteType type, int index)
    {
        public enum WriteType
        {
            Buffer,
            Image
        }

        public VkWriteDescriptorSet Write = write;
        public WriteType Type = type;
        public int Index = index;
    }
    
    private List<VkDescriptorImageInfo> myImageInfos = new();
    private List<VkDescriptorBufferInfo> myBufferInfos = new();
    private List<DescriptorWrite> myWrites = new();
    
    public void WriteImage(uint aBinding, ImageView aImageView, VkSampler aSampler, VkImageLayout aImageLayout, VkDescriptorType aType)
    {
        VkDescriptorImageInfo imageInfo = new();
        imageInfo.sampler = aSampler;
        imageInfo.imageView = aImageView.MyVkImageView;
        imageInfo.imageLayout = aImageLayout;

        myImageInfos.Add(imageInfo);

        VkWriteDescriptorSet write = new();
        write.dstBinding = aBinding;
        write.descriptorCount = 1;
        write.descriptorType = aType;

        myWrites.Add(new(write, DescriptorWrite.WriteType.Image, myImageInfos.Count - 1));
    }
    
    public void WriteBuffer(uint aBinding, VkBuffer aBuffer, ulong aSize, ulong aOffset, VkDescriptorType aType)
    {
        VkDescriptorBufferInfo bufferInfo = new();
        bufferInfo.buffer = aBuffer;
        bufferInfo.offset = aOffset;
        bufferInfo.range = aSize;

        myBufferInfos.Add(bufferInfo);

        VkWriteDescriptorSet write = new();
        write.dstBinding = aBinding;
        write.descriptorCount = 1;
        write.descriptorType = aType;

        myWrites.Add(new(write, DescriptorWrite.WriteType.Buffer, myBufferInfos.Count - 1));
    }
    
    public void Clear()
    {
        myImageInfos.Clear();
        myBufferInfos.Clear();
        myWrites.Clear();
    }
    
    public void UpdateSet(VkDescriptorSet aSet)
    {
        var spanBufferInfos = myBufferInfos.AsSpan();
        var spanImageInfos = myImageInfos.AsSpan();
        VkWriteDescriptorSet[] descriptorSets = new VkWriteDescriptorSet[myWrites.Count];
        for (int i = 0; i < myWrites.Count; i++)
        {
            var write = myWrites[i];

            write.Write.dstSet = aSet;
            
            switch(write.Type)
            {
                case DescriptorWrite.WriteType.Buffer:
                    ref VkDescriptorBufferInfo bufferInfo = ref spanBufferInfos[write.Index];
                    
                    fixed(VkDescriptorBufferInfo* bufferInfoP = &bufferInfo)
                    {
                        write.Write.pBufferInfo = bufferInfoP;
                    }
                    break;
                case DescriptorWrite.WriteType.Image:
                    ref VkDescriptorImageInfo imageInfo = ref spanImageInfos[write.Index];
                    
                    fixed(VkDescriptorImageInfo* imageInfoP = &imageInfo)
                    {
                        write.Write.pImageInfo = imageInfoP;
                    }
                    break;
            }

            descriptorSets[i] = write.Write;
        }

        vkUpdateDescriptorSets(Device.MyVkDevice, new ReadOnlySpan<VkWriteDescriptorSet>(descriptorSets));
    }
}
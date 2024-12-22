using Utilities;

namespace VulkanApi;

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
    
    private List<VkDescriptorImageInfo> ImageInfos = new();
    private List<VkDescriptorBufferInfo> BufferInfos = new(); 
    private List<DescriptorWrite> Writes = new();
    
    public void WriteImage(uint aBinding, ImageView aImageView, Sampler? aSampler, VkImageLayout aImageLayout, VkDescriptorType aType)
    {
        VkDescriptorImageInfo imageInfo = new();
        imageInfo.sampler = aSampler?.VkSampler ?? VkSampler.Null;
        imageInfo.imageView = aImageView.VkImageView;
        imageInfo.imageLayout = aImageLayout;

        ImageInfos.Add(imageInfo);

        VkWriteDescriptorSet write = new();
        write.dstBinding = aBinding;
        write.descriptorCount = 1;
        write.descriptorType = aType;

        Writes.Add(new(write, DescriptorWrite.WriteType.Image, ImageInfos.Count - 1));
    }
    
    public void WriteBuffer(uint aBinding, VkBuffer aBuffer, ulong aSize, ulong aOffset, VkDescriptorType aType)
    {
        VkDescriptorBufferInfo bufferInfo = new();
        bufferInfo.buffer = aBuffer;
        bufferInfo.offset = aOffset;
        bufferInfo.range = aSize;

        BufferInfos.Add(bufferInfo);

        VkWriteDescriptorSet write = new();
        write.dstBinding = aBinding;
        write.descriptorCount = 1;
        write.descriptorType = aType;

        Writes.Add(new(write, DescriptorWrite.WriteType.Buffer, BufferInfos.Count - 1));
    }
    
    public void Clear()
    {
        ImageInfos.Clear();
        BufferInfos.Clear();
        Writes.Clear();
    }
    
    public void UpdateSet(VkDescriptorSet aSet)
    {
        var spanBufferInfos = BufferInfos.AsSpan();
        var spanImageInfos = ImageInfos.AsSpan();
        VkWriteDescriptorSet[] descriptorSets = new VkWriteDescriptorSet[Writes.Count];
        for (int i = 0; i < Writes.Count; i++)
        {
            var write = Writes[i];

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

        vkUpdateDescriptorSets(Device.VkDevice, new ReadOnlySpan<VkWriteDescriptorSet>(descriptorSets));
    }
}
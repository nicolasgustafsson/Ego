What is a device?
	The physical device that vulkan interacts with. Generally the GPU
What is the host?
	The host for vulkan. The computer. 
What is Device Local memory?
	Memory local to the device. Cannot be interacted with outside the device.
 	Host Local is also a thing, meaning that memory is on the host. It's still visible to the device.
	All memory allocated through vulkan is device visible(just allocate outside the vulkan)
What is a Queue?
	A queue is where work is submitted on the physical device. They are an interface to execution engines of devices
What is a Queue Family?
	Each queue belongs to a family. These determine what kind of work the queue can do.
	Generally you want to use queues of families made for the purpose of work.
	For instance, you want to use a dedicated transfer queue to transfer memory, like when uploading textures or models.
What is an Execution Engine?
	Things that Execute work submitted through Queues. execution engines/Compute Units/Cuda cores are all execution engines.
What is a DMA transfer?
	Direct Memory Access Transfer; this is when you transfer host local memory to device local memory
What is the difference between Command Buffer actions and Device calls?
	Command buffer actions are used on execution engines. Device calls are interacting with other parts of the device.
What's an image?
	Texture.
What's an image view?
	What we use to interface with the texture. represents a specific part of an image.
What's a frame buffer?
	A collection of image views to use as targets. These can be (multiple)color, depth and stencil. Used in the swapchain. It's not actually a buffer, it's just being a little silly
What's a pipeline?
	Describes the "path" data takes when executing a render command. Things such as use vertex shader, fragment shader, how to handle depth, etc.
	You need to compile these ahead of time. 
	To compile a pipeline, you need to set up a pipeline layout. Then you compile it.
Why not just create a pipeline layout at the same time as the pipeline? and just use the pipeline.
	Yeah we can do this.
Do you need a frame buffer to draw to a texture?
	No. With dynamic rendering, we don't need frame buffers. If we use render passes, we do need them.
Can you use image views to implement mipmapping?

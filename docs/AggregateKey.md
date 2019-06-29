# Aggregate keys

In DDD we have to find our own solution to the aggregate identification. This is important if we want to change the state of a specific aggregate - the command must include some kind of identifier of the aggregate.

In the source code of a DDD project, the aggregate is loaded from the repository by the identifier included in the command. But in PESS, the concept of command handler is hidden in the generated code.

From the view of the domain expert, the key of the aggregate must exist and must be unique. It's something the domain expert does not need to work with. That's why PESS separates commands to creational and updating. Updating command always requires a key but what that value concerns the developer, not the domain expert.

PESS requires that the value of the aggregate key:

- should be relatively easy to compare with another value visually
- should be possible to simply copy and paste the value of the key

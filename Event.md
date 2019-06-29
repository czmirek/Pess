# Event

In DDD combined with ES, the event from the view of the developer is just a class that gets serialized into the event sourcing repository. The class itself represents the change that has happened in the aggregate.

In PESS, the event is something like an "assignment function". It is not merely a container of properties but a description of a function.

The PESS event consists of:

- at least one aggregate property reference, at most all of them
- unique name of the event

This means that PESS restricts events to be related only to properties of aggregates and does not allow events to have their own structure.

This is by design because in the code, the developer must be able to reconstruct the state of the aggregate from the collection of events only. This is why in PESS the event describes the assignment and it's not a mere data container (but a similar container is generated in the code later).



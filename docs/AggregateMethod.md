# The body of the aggregate method

In DDD, the aggregate is completely isolated from everything else and concerns itself with its own state only.

Combined with event sourcing, the method of the aggregate performs only these 3 types of operations:

- validation
- transformation
- assignment

## Validation

Validation reads the command's input and except in a creational command also the current state of the aggregate. All these properties are read only and cannot be assigned to.

During validation the input and aggregate's state are checked for conforming the business rules and context.

## Transformation

...

## Code complexity during validation and transformation

In complex...

## Input of the aggregate method

The input of the aggregate method consists of:

- command properties
- aggregate properties (aggregate's current state)


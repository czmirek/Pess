# Aggregates and properties

The aggregate is the main building block of DDD. The aggregate represents the "business object" completely isolated from other aggregates. In PESS, the aggregate consist of:

- unique name of the aggregate
- properties
- creation commands
- update commands

## Aggregate properties

The property has a name and a type. The type of the property can be:

- a simple property
- a value object

## Simple properties

The simple property consists of a name and a simple type or a collection type.

## Simple types

The simple types are aimed at humans with no programming skills but are defined precisely enough for a generator to generate a code in a programming language.

The simple types can have a collection of predefined constraints or extensions. These are discussed later.

- ``text``: Any UTF-8 string.
- ``number``: Any positive or negative number with zero and with a finite number of digits in both integer part and fractional part. The number must NOT loose precision if it contains the fractional part.
- ``boolean``: true or false
- ``time``: Date and a time in a specific timezone.

## Collection types

There are two collection types.

- ``list``: a collection of items with zero-based index accessor. The list can be constrained to a specific simple, collection or value object type but the constraint is optional and the list can contain values of multiple types.
- ``dictionary``: a key-value based collection. The key can be only a simple type and there must be no multiple keys with same value. The type of the key must be defined but the constraint on the type of the value is optional.

Both list and dictionary must be fully manipulable and accessible.

## Value objects

Value objects are custom named structures of properties. They are equivalent to classes in OOP. They are contained within aggregates but apart from aggregates they only represent data containers with custom structures in aggregates and have no support for their own methods.

Properties inside value objects can have the same types as aggregates: simple types, collection types or other value objects.

## Default values or properties

PESS does not consider default values and requires all properties to be set explicitly when aggregate is created.

Collection types must be explicitly set to empty collections during aggregate creation.

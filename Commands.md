# Commands

In DDD, the command is a structure that is consumed by the DDD framework (in some kind of command hub) and redirected to a predefined command handler which then initializes or loads the relevant instance of the aggregate class, invokes the relevant method and passes the data in the command if there were any.

The "command handler" is something the domain expert does not really care about. It's purpose is to manage the state of the aggregate instance but that is relevant to the concepts of object oriented programming, this does not really have anything to do with the domain.

Therefore in PESS the "command handler" does not exist. Instead, commands are special structures **inside** the aggregate. All aggregates can have unlimited number of commands.

## Command structure

- **Command type**: the command can be either *creational* or *updating*. A creational command creates a new aggregate, updating command alters an existing aggregate.
- **Command complexity**: the command can be either *trivial* or *complex*.

## Creational and updating command

All aggregates must have at least one creational command. The creational command creates a new aggregate and must set all the properties of the aggregate to the default value.

Updating command references an already existing aggregate

## Trivial command

Trivial commands by definition do not perform custom validations or transformations. They can be configured by the domain expert a do not need the developer.

**Creational trivial** command is the most simple command. By definition, the command structure of this command is identical to the structure of the aggregate but it is expected that the values of the command have been already set from outside.

**Updating trivial** command specifies at least one aggregate property, more of them or all of them. The updating command then simply updates the state of the aggregate.

## Complex command

A complex command contains a "complex command handler" (CCH) that performs the necessary validations, transformations and assignments to the state of the aggregate.

The most simple CCH presents itself as a simple text input to the domain expert. This input enters the aggregate class source code as a comment for the developer to build upon.

The CCH represents the "hard part" of DDD development. It's something the domain expert cannot build by himself.



The CCH consists of these 3 parts:

- validation
- transformation
- assignment





The most simple "handler" is just a text entered by the domain expert that enters the generated aggregate class in a comment. The developer writes the code necessary to perform the validations and transformations as commented by the domain expert.


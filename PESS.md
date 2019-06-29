# Programmable Event Sourced Site (PESS)

(Idea + Work In Progress)

## My motivation about DDD and ES

I've been always fascinated by Domain Driven Development (DDD) and Event Sourcing (ES) concepts.

Especially:

- how the code in DDD should always be 1:1 with what the business experts want
- how those ideas are represented as individual changes to the current state and the concept of persistence is separated somewhere else
- how the collection of changes builds the complete history of the domain (Event Sourcing) and how read models (CQRS) and eventual consistency perfectly fits into this.

## The idea

After creating my first relatively large project in DDD/ES and getting a deep understanding of those concepts, I realized that creating a DDD/ES project is not a trivial task 
because of the framework code required.

After some research though I found that there is only one part in DDD/ES programming that is hard - data validation and transformation. This is something a domain/business expert expresses in language or written text but requires a programmer to transform those ideas to a working code.

**And that's the whole idea.**

The only "hard" part of DDD/ES development is data validation and transformation because it is the only part that requires "the developer". (Even that is debatable though.)

"PESS" is the project that attempts to isolate this problem for a human and have everything else done automatically or with a nice user interface without the need to write any other code. This leads to two "roles" of users using PESS.

- *the domain expert*: this guy works with PESS, creates and configures aggregates, their properties and commands. This guy doesn't know how to code but in a normal language he can explain how a specific aggregate method validates and transforms the data of the command combined with the current state of the aggregate to the new state of the aggregate.

- *the developer*: his only job is to convert the validation and transformation expressed by the domain expert from written language into a workable code.

PESS attempts to create a nice interface for these two roles. The domain experts constructs the domain and the developer only converts the domain expert's ideas into actual code. PESS will generate the source code for the developer or even push into a git repository. Another ability of PESS is to generate the code and run it immediately. The whole domain can then be exposed as a REST API with just a single click.

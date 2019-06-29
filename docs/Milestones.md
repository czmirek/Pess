# Milestones

## 0.1.0

- Pess.Data = Data repository library with interfaces containing IPessRepository
- Pess.Data.Xml = XML repository for projects and users. Users are in separate file. Password is plaintext for now.
- Website layout = simple bootstrap, menu with login link
- Homepage = empty site
- Homepage for signed up user = Projects link
- List projects
- Add project (name, description)
- Edit project (name, description)
- List aggregates in project
- Add Aggregate in project (name, description)
- Edit aggregate in project (name, description)

## 0.2.0

- Add property to aggregate (name, description, type)
- Simple property types: string, number, boolean, time, interval
- Remove property from aggregate

## 0.3.0

- Add command to aggregate (name, description, creational/updating, trivial/complex)
- Remove command from aggregate

## 0.4.0

- Add selection of properties from the aggregate to the command. Only for trivial commands.

## 0.5.0

- Add property definitions for complex commands.
- Basic constraints for simple types

## 0.6.0

- CCH abstraction: form generation, controller and data repository.
- CCH type: comment input - visible for user in domain expert role
- CCH code - visible for user in developer role. Language: C# + Code content. Only for complex commands.

## 0.7.0

- EventFlow C# solution code generator
- Event Store support

## 1.0.0

- dotnet.exe support - build EventFlow and run REST API service immediately.
- Documentation
- Example project

## 1.1.0

- List and dictionary support
- Value objects support
- Event Store browser
- Updated documentation
- Quality of code and comments revision

## Future

- GIT repository management
- C#/LUA syntax coloring
- CCH interface for further transformations (such as XSLT): command properties, aggregate state and assignments.
- CCH.XSLT transformations
- XSLT validation schemes
- User management
- domain expert: notify developers this is done
- developers: todo list missing code
- global/project/aggregate validators
- global/project/aggregate transformational functions
- global/project/aggregate predefined types
- Tests as part of the generated code

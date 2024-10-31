## DynamicVNET - Overview
[![NuGet](https://img.shields.io/badge/nuget-1.4.0-blue.svg)](https://www.nuget.org/packages/DynamicVNET/1.4.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/rasulhsn/DynamicVNET/blob/master/LICENSE)

DynamicVNET is .NET Standard library that was created help to develop reuse dynamic validation. It helps to build some rules on POCO and own blackbox libs. It has rich conveniences and features as a <strong>Fluent API</strong> in runtime, wrapped over <strong>DataAnnotation</strong> attributes and supports a cross-platform environment.

### Support
 - Branching & Nested Branching.
 - Nested Members.
 - Value Types & Single Primitive.
 - Reference Types (class).
 - Automatic ignoring of repeated validation.
 - Strongly Self Validator via Inheritance.

### Where is using ?
 - POCO Validation.
 - Dynamic validation for private libraries (third party libraries 'dll').

### Validation methods
   - Predicate (Custom)
   - StringLen
   - EmailAddress
   - Url (for GET)
   - Required
   - MaxLen
   - RegularExp
   - Range
   - Null (Only reference type)
   - NotNull (Only reference type)

### Example
POCO Models.
```csharp
public class Employee
{
   public string Name { get; set; }
   public Token TokenNumber { get; set; }
   public string Email { get; set; }
   
}
public class Token
{
   public string Number { get; set; }
}
```
Validation.
```csharp
Employee emp = new Employee()
{
    Name = "Jhon", 
    TokenNumber = new Token() { Number = "2312412312341" }, 
    Email = "jhon.sim@gmail.com"
};

var validator = ValidatorFactory.Create<Employee>(builder => {
                    builder.StringLen(x => x.Name, 4)
                            .EmailAddress(x => x.Email)
                            .Predicate(x => x.Email.Contains("@simple.com"))
                            .Required(x => x.TokenNumber.Number) //  nested member
                            .Required(x => x.TokenNumber.Number); // automatic ignored
                });        

bool result = validator.IsValid(emp);
``` 

```csharp
// Detailed Result
IEnumerable<ValidationMarkerResult> results = validator.Validate(emp);
```
#### Branch Example
```csharp
 var validator = ValidatorFactory.Create<Model>(builder => {
    builder.Required(x => x.Token.TokenNumber)
            .Branch(x => x.Name.Contains("resul"), x =>
             {
                 x.Required(y => y.Email)
                 .StringLen(y => y.Email, 2)
                     .Branch(n => n.Name.Length >= 4,n => {
                          n.MaxLen(s => s.Token.TokenNumber, length: 4);
                       });
            }).Branch(x => x.Email.Contains("aa"), x =>
              {
                  x.Required(y => y.Name)
                  .StringLen(y => y.Name, 5)
                  .StringLen(y => y.Token.TokenNumber, 9);
             });     
 });
```

## Example Strongly Self Validator

```csharp
public class EmployeeValidator : BaseValidator<Employee>
{
      protected override void Setup(ValidatorBuilder<Employee> builder)
      {
           builder.For(x => x.Name)
                  .Required();

           builder.Branch(x => x.Name.Contains("Jhon"), x =>
                   {
                      x.MaxLen(m => m.TokenNumber.Number, 15);
                   })
                   .For(x => x.Email)
                    .Required()
                    .EmailAddress();

           builder.Required(x => x.TokenNumber.Number);
      }
}
 
Employee emp = new Employee()
{
    Name = "Jhon Simon", 
    TokenNumber = new Token() { Number = "ASD123123" }, 
    Email = "jhon.sim@jhona.com"
};
 
 var empValidator = new EmployeeValidator();
 bool result = empValidator.IsValid(emp);
```

### Where can I get it?

Install [DynamicVNET](https://www.nuget.org/packages/DynamicVNET/) from the package manager console:

```
PM> Install-Package DynamicVNET -Version 1.4.0
```

### Copyright

[DynamicVNET](https://github.com/rasulhsn/DynamicVNET) is Copyright © 2018 Rasul Huseynov.

## DynamicVNET - Overview
[![NuGet](https://img.shields.io/badge/nuget-1.4.0.beta-blue.svg)](https://www.nuget.org/packages/DynamicVNET/1.4.0-beta)

DynamicVNET is a .NET Standard library that was created to develop dynamic reuse validation. The main idea of the library is to apply validation rules using a declarative approach. And the rules can be used on POCO and BlackBox libraries. Also, it has rich facilities and features as Fluent API at runtime.


### Support
 - Branching & Nested Branching [synonim logical tree].
 - Nested Members.
 - Value Types & Single Primitive & Reference Types (class)
 - Auto Ignore (Ignoring of repeated validation).
 - Strongly Typed Validator via Inheritance.

### Where is using ?
 - POCO validation.
 - Dynamic validation for private libraries (third party libraries).

### Validation methods
   - Predicate (Custom)
   - StringLen
   - EmailAddress
   - PhoneNumber
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

var validator = ValidatorFacade.Create<Employee>(builder => {
                    builder.Marker
                            .StringLen(x => x.Name, 4)
                            .EmailAddress(x => x.Email)
                            .Predicate(x => x.Email.Contains("@simple.com"))
                            .Required(x => x.TokenNumber.Number) //  nested member
                            .Required(x => x.TokenNumber.Number); // auto ignore
                });        

bool result = validator.IsValid(emp);
``` 
Detailed Result.
```csharp

IEnumerable<ValidationMarkerResult> results = validator.Validate(emp);
```
#### Branch Example
```csharp
 var validator = ValidatorFacade.Create<Model>(builder => {
    builder.Marker
            .Required(x => x.Token.TokenNumber)
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
        public EmployeeValidator()
        {
            Setup(builder =>
            {
                builder.Marker
                       .For(x => x.Name)
                       .Required();

                builder.Marker
                      .Branch(x => x.Name.Contains("jhon"), x =>
                      {
                        x.MaxLen(m => m.TokenNumber.Number, 15);
                      })
                      .For(x => x.Email)
                      .Required()
                      .EmailAddress();

                builder.Marker
                     .Required(x => x.TokenNumber.Number);
            });
            
        }
}
 
 Employee emp = new Employee()
{
    Name = "rasul:huseynov", 
    TokenNumber = new Token() { Number = "1111111123123ASD" }, 
    Email = "jhon.1990@gmail.com"
};
 
 
 var empValidator = new EmployeeValidator();
 bool result = empValidator.IsValid(emp);
```

### Where can I get it?

Install [DynamicVNET](https://www.nuget.org/packages/DynamicVNET/) from the package manager console:

```
PM> Install-Package DynamicVNET -Version 1.4.0-beta
```

### License & Copyright

[DynamicVNET](https://github.com/rasulhsn/DynamicVNET) is Copyright © 2018-2021 Rasul Huseynov and lincensed under the [MIT license](https://github.com/rasulhsn/DynamicVNET/blob/master/LICENSE).

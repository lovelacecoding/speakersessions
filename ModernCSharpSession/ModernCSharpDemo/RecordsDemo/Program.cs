using RecordsDemo;

//TO-DO: Create person class & person record
//TO-DO: Test out person class & person record
//TO-DO: Test Equality (ref/value)

PersonClass personClass = new PersonClass("Lou", "Creemers"); 
PersonClass personClass2 = new PersonClass("Lou", "Creemers"); 
PersonRecord personRecord = new PersonRecord("Lou", "Creemers");
PersonRecord personRecord2 = new PersonRecord("Lou", "Creemers");

Console.WriteLine(personRecord == personRecord2);
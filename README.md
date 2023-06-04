# KissMap
A simple object mapper in C#.

## Q. Why another object mapper?
### A. Because I wanted something simple.

## Usage
``` 
var mapper = new ObjectMapper<TSource,TDest>();
mapper.Register("propname1");
mapper.Register("propname2");
mapper.Register("propnameetc");
var newObjects = myListOfObjects.Select(mapper.CreateFrom);
```


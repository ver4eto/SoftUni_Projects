﻿
[AttributeUsage (AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
   // private string name;

    public AuthorAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get;set; }
}
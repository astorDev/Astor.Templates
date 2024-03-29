﻿namespace Astor.Template.Tests;

[TestClass]
public class AboutShould : Test
{
    [TestMethod]
    public async Task ReturnValidMetadata()
    {
        var client = this.Factory.Create();

        var about = await client.GetAboutAsync();
            
        Assert.AreEqual("Astor.Template - template API", about.Description);
        Assert.AreEqual("1.0.0.0", about.Version);
        Assert.AreEqual("Development", about.Environment);
    }
}
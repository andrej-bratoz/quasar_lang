using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuasarLang.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void SampleAssignment()
        {
            var program = @"
                var x = 10;
            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);
            
        }

        [TestMethod]
        public void SampleMethodDefinition()
        {
            var program = @"
                func test(){ var x = 10; }
                            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void SampleMethodMultipleFunctionsDefinition()
        {
            var program = @"
                use 'Test';
                func test(){ var x = 10;
                             var y = 20;}
                            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void SampleMethodMultipleFunctionsDefinition2()
        {
            var program = @"
                func test(){ var x = 10;
                var y = 20;
                break;
                continue;
                return 0;
                }
                ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void Loops()
        {
            var program = @"
              while(a < 10) 
              { 
                return;
              }     

              for(a; a < 100; a = a+1)
              { 
                return;
              }   

              foreach(a in collection)
              { 
                return;
              }    
            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void If()
        {
            var program = @"
              if (a > b) { return; }
            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void IfElse()
        {
            var program = @"
              if (a > b) { return; }
              else { return; }
            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void IfElse2()
        {
            var program = @"
              if (a > b) { return; }
              else if(c > d) { return; }
            ";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Class()
        {
            var program = @"class Test { func x() { return; }}";
            var compiler = new Compiler();
            var result = compiler.Compile(program);
            Assert.AreEqual(result, true);
        }
    }
}

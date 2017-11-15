using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Sand.Api;
using Sand.Extension;
using Xunit;

namespace Sand.Test
{
    public class HelperTest
    {
        private readonly IBaseDataRepository _baseDataRepository;
        //public HelperTest(IBaseDataRepository baseDataRepository)
        //{
        //    _baseDataRepository = baseDataRepository;
        //}

        [Fact]
        public void IsEmpty()
        {
            var str = "1";
            Assert.Equal(str.IsEmpty(), false);
        }

        [Fact]
        public void IsNotEmpty()
        {
            var str = "1";
            Assert.Equal(str.IsNotEmpty(), true);
        }

        [Fact]
        public void IsWhiteSpaceEmpty()
        {
            var str = "  ";
            Assert.Equal(str.IsWhiteSpaceEmpty(), true);

            var str1 = " ";
            Assert.Equal(str1.IsWhiteSpaceEmpty(), true);

            var str2 = "1";
            Assert.Equal(str2.IsWhiteSpaceEmpty(), false);
        }

        [Fact]
        public void IsNotWhiteSpaceEmpty()
        {
            var str = "  ";
            Assert.Equal(str.IsNotWhiteSpaceEmpty(), false);

            var str1 = " ";
            Assert.Equal(str1.IsNotWhiteSpaceEmpty(), false);

            var str2 = "1";
            Assert.Equal(str2.IsNotWhiteSpaceEmpty(), true);
        }

        [Fact]
        public void Guid()
        {
            var list = new List<Guid>();
            Guid first;
            Guid end;
            for (int i = 0; i < 10000; i++)
            {
                //Thread.Sleep(1);
                var guid = Helpers.Uuid.Next();
                if (i == 0)
                {
                    first = guid;
                }
                if (i == 9999)
                {
                    end = guid;
                }
                list.Add(guid);
            }
            Assert.Equal(first, list.Min());
            Assert.Equal(end, list.Max());
        }
    }
}

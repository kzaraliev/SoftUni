using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public interface IIndivid
    {
        string Name { get; }
        string Id { get; }

        void CheckId(string fakeSubstring);
    }
}

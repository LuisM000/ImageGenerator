using System;
using System.Drawing;

namespace ImageGenerator.Abstractions
{
    public interface IImage : IDisposable
    {
        int Width { get; }
        int Height { get; }
    }
}

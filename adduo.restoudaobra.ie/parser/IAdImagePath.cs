using System;

namespace adduo.restoudaobra.ie.parser
{
    public interface IAdImagePath
    {
        void SetGuidProduct(Guid guid);
        string RelativePath();
        string PhysicalPath();
        string FullPhysicalPath(string file);
        string FullRelativePath(string file);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace XmlExternalEntitiesUnsafeApi.Util
{
    public class SafeXmlUrlResolver : XmlUrlResolver
    {
        public SafeXmlUrlResolver()
        {
        }


        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            if (absoluteUri == null)
                throw new ArgumentNullException("absoluteUri");

            // Disallow anything other than files
            if (!absoluteUri.IsFile)
                throw new ApplicationException($"Cannot read URI {absoluteUri}.  This is prohibited");

            if (Path.GetDirectoryName(absoluteUri.LocalPath) != "C:\\DocumentTypeDefinitions")
                throw new ApplicationException($"Cannot read URI {absoluteUri}.  This is prohibited");

            return base.GetEntity(absoluteUri, role, ofObjectToReturn);
        }
    }
}
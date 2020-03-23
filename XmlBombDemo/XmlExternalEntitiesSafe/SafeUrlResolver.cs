using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlExternalEntitiesSafe
{
    public class SafeUrlResolver : XmlUrlResolver
    {


        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            return base.GetEntity(absoluteUri, role, ofObjectToReturn);
        }
    }
}

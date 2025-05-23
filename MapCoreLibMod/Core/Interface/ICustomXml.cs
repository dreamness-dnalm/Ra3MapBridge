﻿using System;
using System.Xml;

namespace MapCoreLibMod.Core.Interface
{
    public interface ICustomXml
    {
        void toXml(XmlDocument document, XmlElement root, MapDataContext context, Object asset);

        void toObj(XmlDocument document, XmlElement root, MapDataContext context, Object asset);

    }
}
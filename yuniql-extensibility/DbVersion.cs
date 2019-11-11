﻿using System;

namespace ArdiLabs.Yuniql.Extensibility
{
    public class DbVersion
    {
        //unique sequence id for the version
        public int Id { get; set; }

        //the version itself as reflected in the directory structure
        public string Version { get; set; }

        //the date and time when migration was run
        public DateTime DateInsertedUtc { get; set; }

        //the user id used who performed the migration
        public string LastUserId { get; set; }

        //some additional information on the version
        public string Comment { get; set; }
    }
}
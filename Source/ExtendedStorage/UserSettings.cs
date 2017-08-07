﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace ExtendedStorage {
    public class UserSettings : StorageSettings, IExposable {
        private IUserSettingsOwner _owner;

        [Obsolete("Do not use directly - needed for serializer")]
        public UserSettings()
        {
        }

        public UserSettings(IUserSettingsOwner owner) : base(owner)
        {
            _owner = owner;
        }


        public void NotifyOwnerSettingsChanged() 
        {
            _owner.Notify_UserSettingsChanged();
        }

        void IExposable.ExposeData() {
            base.ExposeData();
            Scribe_References.Look(ref _owner, "owner", false);
        }

    }
}
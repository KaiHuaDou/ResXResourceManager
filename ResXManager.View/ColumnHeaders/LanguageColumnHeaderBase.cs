﻿namespace tomenglertde.ResXManager.View.ColumnHeaders
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using tomenglertde.ResXManager.Infrastructure;
    using tomenglertde.ResXManager.Model;

    using TomsToolbox.Desktop;

    public abstract class LanguageColumnHeaderBase : ObservableObject, ILanguageColumnHeader
    {
        private readonly CultureKey _cultureKey;
        private readonly Configuration _configuration;

        protected LanguageColumnHeaderBase(Configuration configuration, CultureKey cultureKey)
        {
            Contract.Requires(configuration != null);
            Contract.Requires(cultureKey != null);

            _configuration = configuration;
            _cultureKey = cultureKey;
        }

        public CultureKey CultureKey => _cultureKey;

        public CultureInfo EffectiveCulture => _cultureKey.Culture ?? _configuration.NeutralResourcesLanguage;

        public abstract ColumnType ColumnType
        {
            get;
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_configuration != null);
            Contract.Invariant(_cultureKey != null);
        }
    }
}
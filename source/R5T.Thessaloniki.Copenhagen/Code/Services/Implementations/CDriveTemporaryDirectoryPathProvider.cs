using System;

using R5T.Copenhagen;
using R5T.Lombardy;
using R5T.Troy;using R5T.T0064;


namespace R5T.Thessaloniki.Copenhagen
{[ServiceImplementationMarker]
    public class CDriveTemporaryDirectoryPathProvider : ITemporaryDirectoryPathProvider,IServiceImplementation
    {
        private ICDrivePathProvider CDrivePathProvider { get; }
        private ITemporaryDirectoryNameConvention TemporaryDirectoryNameConvention { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public CDriveTemporaryDirectoryPathProvider(
            ICDrivePathProvider cDrivePathProvider,
            ITemporaryDirectoryNameConvention temporaryDirectoryNameConvention,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.CDrivePathProvider = cDrivePathProvider;
            this.TemporaryDirectoryNameConvention = temporaryDirectoryNameConvention;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetTemporaryDirectoryPath()
        {
            var cDrivePath = this.CDrivePathProvider.GetCDrivePath();

            var temporaryDirectoryName = this.TemporaryDirectoryNameConvention.GetTemporaryDirectoryName();

            var temporaryDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(cDrivePath, temporaryDirectoryName);
            return temporaryDirectoryPath;
        }
    }
}

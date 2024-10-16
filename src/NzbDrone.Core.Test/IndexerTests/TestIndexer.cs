using NLog;
using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Indexers;
using NzbDrone.Core.Messaging.Events;

namespace NzbDrone.Core.Test.IndexerTests
{
    public class TestIndexer : HttpIndexerBase<TestIndexerSettings>
    {
        public override string Name => "Test Indexer";
        public override string BaseUrl => "http://testindexer.com";

        public override DownloadProtocol Protocol => DownloadProtocol.Usenet;

        public override IndexerPrivacy Privacy => IndexerPrivacy.Private;

        public int _supportedPageSize;
        public override int PageSize => _supportedPageSize;

        public TestIndexer(IHttpClient httpClient, IEventAggregator eventAggregator, IIndexerStatusService indexerStatusService, IConfigService configService, Logger logger)
            : base(httpClient, eventAggregator, indexerStatusService, configService, logger)
        {
        }

        public IIndexerRequestGenerator _requestGenerator;
        public override IIndexerRequestGenerator GetRequestGenerator()
        {
            return _requestGenerator;
        }

        public IParseIndexerResponse _parser;
        public override IParseIndexerResponse GetParser()
        {
            return _parser;
        }
    }
}

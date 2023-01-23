using System.Collections.Generic;
using NLog;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Indexers.Definitions.Gazelle;
using NzbDrone.Core.Messaging.Events;

namespace NzbDrone.Core.Indexers.Definitions;

public class NotWhatCD : GazelleBase<GazelleSettings>
{
    public override string Name => "notwhat.cd";
    public override string[] IndexerUrls => new[] { "https://notwhat.cd/" };
    public override string Description => "NotWhat.CD (NWCD) is a private Music tracker that arised after the former (WCD) shut down.";
    public override IndexerPrivacy Privacy => IndexerPrivacy.Private;

    public NotWhatCD(IIndexerHttpClient httpClient,
                     IEventAggregator eventAggregator,
                     IIndexerStatusService indexerStatusService,
                     IConfigService configService,
                     Logger logger)
        : base(httpClient, eventAggregator, indexerStatusService, configService, logger)
    {
    }

    protected override IndexerCapabilities SetCapabilities()
    {
        var caps = new IndexerCapabilities
        {
            TvSearchParams = new List<TvSearchParam>
            {
                TvSearchParam.Q, TvSearchParam.Season, TvSearchParam.Ep
            },
            MovieSearchParams = new List<MovieSearchParam>
            {
                MovieSearchParam.Q
            },
            MusicSearchParams = new List<MusicSearchParam>
            {
                MusicSearchParam.Q, MusicSearchParam.Artist, MusicSearchParam.Album, MusicSearchParam.Label, MusicSearchParam.Year
            },
            BookSearchParams = new List<BookSearchParam>
            {
                BookSearchParam.Q
            }
        };

        caps.Categories.AddCategoryMapping(1, NewznabStandardCategory.Audio, "Music");
        caps.Categories.AddCategoryMapping(2, NewznabStandardCategory.PC, "Applications");
        caps.Categories.AddCategoryMapping(3, NewznabStandardCategory.Books, "E-Books");
        caps.Categories.AddCategoryMapping(4, NewznabStandardCategory.AudioAudiobook, "Audiobooks");
        caps.Categories.AddCategoryMapping(5, NewznabStandardCategory.Movies, "E-Learning Videos");
        caps.Categories.AddCategoryMapping(6, NewznabStandardCategory.TV, "Comedy");
        caps.Categories.AddCategoryMapping(7, NewznabStandardCategory.Books, "Comics");

        return caps;
    }
}

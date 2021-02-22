// <copyright file="WelcomeCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.DIConnect.Cards
{
    using System;
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Localization;
    using Microsoft.Teams.Apps.DIConnect.Common;
    using Microsoft.Teams.Apps.DIConnect.Common.Resources;
    using Microsoft.Teams.Apps.DIConnect.Constants;
    using Microsoft.Teams.Apps.DIConnect.Models;

    /// <summary>
    /// Class that helps to return welcome card as attachment.
    /// </summary>
    public static class WelcomeCard
    {
        /// <summary>
        /// Get welcome card attachment to show on Microsoft Teams personal scope.
        /// </summary>
        /// <param name="localizer">The current culture's string localizer.</param>
        /// <param name="applicationManifestId">Application manifest id.</param>
        /// <returns>End user welcome card attachment.</returns>
        public static Attachment GetEnduserCard(IStringLocalizer<Strings> localizer, string applicationManifestId)
        {
            AdaptiveCard card = new AdaptiveCard(new AdaptiveSchemaVersion(CardConstants.AdaptiveCardVersion))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("WelcomeTitleText"),
                        Weight = AdaptiveTextWeight.Bolder,
                        Size = AdaptiveTextSize.Large,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("WelcomeHeaderText"),
                        Spacing = AdaptiveSpacing.None, 
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("WelcomeSubHeaderText"),
                        Spacing = AdaptiveSpacing.None,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = "* " + localizer.GetString("DiscoverGroupBulletPoint"),
                        Wrap = true,
                        Spacing = AdaptiveSpacing.None,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = "* " + localizer.GetString("QueriesBulletPoint"),
                        Wrap = true,
                        Spacing = AdaptiveSpacing.None,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = "* " + localizer.GetString("ConnectPeopleBulletPoint"),
                        Wrap = true,
                        Spacing = AdaptiveSpacing.None,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = "* " + localizer.GetString("BroadcastMessageBulletPoint"),
                        Wrap = true,
                        Spacing = AdaptiveSpacing.None,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("WelcomeContentText"),
                        Wrap = true,
                    },
                },

                Actions = new List<AdaptiveAction>
                {
                    new AdaptiveOpenUrlAction
                    {
                        Title = localizer.GetString("DiscoverGroupButtonText"),
                        Url = new Uri($"{DeepLinkConstants.TabBaseRedirectURL}/{applicationManifestId}/{CardConstants.DiscoverGroupTabEntityId}"),
                    },
                    new AdaptiveSubmitAction
                    {
                        Title = "Pause",
                        Data = new AdaptiveSubmitActionData
                        {
                            Msteams = new CardAction
                            {
                                Type = CardConstants.FetchActionType,
                            },
                        },
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card,
            };
        }
    }
}
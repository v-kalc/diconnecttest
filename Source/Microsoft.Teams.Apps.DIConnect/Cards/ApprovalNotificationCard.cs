// <copyright file="ApprovalNotificationCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.DIConnect.Cards
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Localization;
    using Microsoft.Teams.Apps.DIConnect.Common;
    using Microsoft.Teams.Apps.DIConnect.Common.Resources;
    using Microsoft.Teams.Apps.DIConnect.Constants;

    /// <summary>
    /// Class that helps to return approval notification card as attachment.
    /// </summary>
    public static class ApprovalNotificationCard
    {
        /// <summary>
        /// Get approval notification card attachment.
        /// </summary>
        /// <param name="localizer">The current culture's string localizer.</param>
        /// <param name="applicationBasePath">Represents the Application base URI.</param>
        /// <returns>Approval notification card attachment.</returns>
        public static Attachment GetCard(IStringLocalizer<Strings> localizer, string applicationBasePath)
        {
            AdaptiveCard card = new AdaptiveCard(new AdaptiveSchemaVersion(CardConstants.AdaptiveCardVersion))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveColumnSet
                    {
                        Columns = new List<AdaptiveColumn>
                        {
                            new AdaptiveColumn
                            {
                                Width = "12",
                                Items = new List<AdaptiveElement>
                                {
                                    new AdaptiveTextBlock
                                    {
                                        Text = localizer.GetString("RequestSubmittedText"),
                                        Weight = AdaptiveTextWeight.Bolder,
                                        Size = AdaptiveTextSize.Large,
                                    },
                                },
                            },
                            new AdaptiveColumn
                            {
                                Width = "3",
                                Items = new List<AdaptiveElement>
                                {
                                    new AdaptiveImage
                                    {
                                        AltText = "not available",
                                    },
                                },
                            },
                        },
                    },
                    new AdaptiveTextBlock
                    {
                        Text = "test the description",
                        Spacing = AdaptiveSpacing.Small,
                        Wrap = true,
                    },
                    GetAdaptiveCardColumnSet(localizer.GetString("NameText"), "test"),
                    GetAdaptiveCardColumnSet(localizer.GetString("TagText"), "test"),
                    GetAdaptiveCardColumnSet(localizer.GetString("LocationText"), "test"),
                    new AdaptiveTextBlock
                    {
                        Size = AdaptiveTextSize.Medium,
                        Separator = true,
                    },
                    GetAdaptiveCardColumnSet(localizer.GetString("SearchEnabledText"), "test"),
                },
            };

            if (true)
            {
                card.Actions.Add(
                    new AdaptiveSubmitAction()
                    {
                        Title = localizer.GetString("ApproveButtonText"),
                    });

                card.Actions.Add(
                    new AdaptiveSubmitAction()
                    {
                        Title = localizer.GetString("RejectButtonText"),
                    });
            }

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card,
            };
        }

        /// <summary>
        /// Get adaptive card column set.
        /// </summary>
        /// <param name="title">Column title.</param>
        /// <param name="value">Column value.</param>
        /// <returns>AdaptiveColumnSet.</returns>
        private static AdaptiveColumnSet GetAdaptiveCardColumnSet(string title, string value)
        {
            return new AdaptiveColumnSet
            {
                Columns = new List<AdaptiveColumn>
                {
                    new AdaptiveColumn
                    {
                        Width = "50",
                        Items = new List<AdaptiveElement>
                        {
                            new AdaptiveTextBlock
                            {
                                Text = $"{title}:",
                                Wrap = true,
                                Weight = AdaptiveTextWeight.Bolder,
                                Size = AdaptiveTextSize.Medium,
                            },
                        },
                    },
                    new AdaptiveColumn
                    {
                        Width = "100",
                        Items = new List<AdaptiveElement>
                        {
                            new AdaptiveTextBlock
                            {
                                Text = value,
                                Wrap = true,
                            },
                        },
                    },
                },
            };
        }
    }
}
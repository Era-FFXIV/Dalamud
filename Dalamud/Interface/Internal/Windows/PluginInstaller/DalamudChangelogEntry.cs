﻿using System;

using ImGuiScene;

namespace Dalamud.Interface.Internal.Windows.PluginInstaller
{
    /// <summary>
    /// Class representing a Dalamud changelog.
    /// </summary>
    internal class DalamudChangelogEntry : IChangelogEntry
    {
        private readonly DalamudChangelog changelog;

        /// <summary>
        /// Initializes a new instance of the <see cref="DalamudChangelogEntry"/> class.
        /// </summary>
        /// <param name="changelog">The changelog.</param>
        /// <param name="icon">The icon.</param>
        public DalamudChangelogEntry(DalamudChangelog changelog, TextureWrap icon)
        {
            this.changelog = changelog;
            this.Icon = icon;

            var changelogText = string.Empty;
            for (var i = 0; i < changelog.Changes.Count; i++)
            {
                var change = changelog.Changes[i];
                changelogText += $"{change.Message} (by {change.Author})";

                if (i < changelog.Changes.Count - 1)
                {
                    changelogText += Environment.NewLine;
                }
            }

            this.Text = changelogText;
        }

        /// <inheritdoc/>
        public string Title => "Dalamud Core";

        /// <inheritdoc/>
        public string Version => this.changelog.Version;

        /// <inheritdoc/>
        public string Text { get; init; }

        /// <inheritdoc/>
        public TextureWrap Icon { get; init; }

        /// <inheritdoc/>
        public DateTime Date => this.changelog.Date;
    }
}

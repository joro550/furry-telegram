function embedTwitch(elementId, streamName) {
    new Twitch.Embed(elementId, {
        width: 853,
        height: 480,
        channel: streamName
      });
}
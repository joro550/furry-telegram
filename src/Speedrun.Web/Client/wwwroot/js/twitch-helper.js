function twitchEmbed(elementId, channelName)
{
    var embed = new Twitch.Embed(elementId, {
        width: 854,
        height: 480,
        channel: channelName,
        layout: "video",
        autoplay: false
    });

    embed.addEventListener(Twitch.Embed.VIDEO_READY, () => {
        var player = embed.getPlayer();
        player.play();
    });
}

var elems = document.querySelectorAll('.sidenav');
var instances = M.Sidenav.init(elems, options);


 var collapsibleElem = document.querySelector('.collapsible');
 var collapsibleInstance = M.Collapsible.init(collapsibleElem, options);
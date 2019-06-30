var prev = null;
var curr = null;
var next = null;

function doOnLoad() {
    alert("Entra");
    scheduler.config.multi_day = true;

    scheduler.init('scheduler_here', new Date(2017, 9, 11), "week");
    scheduler.load("../common/events.json")

    var calendar = scheduler.renderCalendar({
        container: "cal_here",
        navigation: true,
        handler: function (date) {
            scheduler.setCurrentView(date, scheduler.getState().mode);
        }
    });
    scheduler.linkCalendar(calendar);

    scheduler.setCurrentView();
}
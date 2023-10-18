function tableActive(element) {
  $(".table tbody tr").removeClass("tr_active");
  $(element).addClass("tr_active");
}

$(".table tbody tr").click(function () {
  if ($(this).hasClass("tr_active")) return;

  var id = $(this).attr("id");

  tableActive($(this));
  details(id);
});

function details(id) {
  $.ajax({
    url: "/Document/Details/" + id,

    beforeSend: function () {
      $("#loader").show();
      $(".content").hide();
    },
    success: function (data) {
      setTimeout(function () {
        var doc = $($.parseHTML(data));
        $(".container_side .content").html(
          doc.filter(".container_render").html()
        );
        $("#loader").hide();
        $(".content").show();
      }, 600);
    },
  });
}

var firstTr = $(".table tbody tr:nth-child(1)");

if (firstTr.attr("id") != undefined) {
  tableActive(firstTr);
}

function menu(index) {
  $(".menu .list").removeClass("active");
  $(".menu .list").eq(index).removeClass("inactive");
  $(".menu .list").eq(index).addClass("active");
}

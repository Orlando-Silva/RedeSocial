$(document).ready(function () {


    $("#comentario").val(" ");

    $(document).on('keydown', '#gifsearch', function (e) {

        var apiKey = "fiemt6ulZaEDnhtYYXNzQgNvnYCS387D";
        var searchQuery = $("#gifsearch").val().replace(" ", "+");

        if (e.which === 13 || e.keyCode === 13) {

            $.ajax({
                url: 'http://api.giphy.com/v1/gifs/search?q=' + searchQuery + '&api_key=' + apiKey + '&limit=25',
                async: true,
                method: "GET",
                success: function (response) {
                    PopulateGifSearchResult(response.data,false);
                },
                error: function (error) {
                    alert('Erro ao procurar Gifs: ' + error + '.');
                }
            });
        }
    });

    $(document).on('keydown', '#gifsearchPost', function (e) {

        var apiKey = "fiemt6ulZaEDnhtYYXNzQgNvnYCS387D";
        var searchQuery = $("#gifsearchPost").val().replace(" ", "+");

        if (e.which === 13 || e.keyCode === 13) {

            $.ajax({
                url: 'http://api.giphy.com/v1/gifs/search?q=' + searchQuery + '&api_key=' + apiKey + '&limit=25',
                async: true,
                method: "GET",
                success: function (response) {
                    PopulateGifSearchResult(response.data,true);
                },
                error: function (error) {
                    alert('Erro ao procurar Gifs: ' + error + '.');
                }
            });
        }
    });

    $(document).on('click', '#buttonComentar', function (e) {

        $("#conteudoComentario").val($("#comentario").html());

    });

    $(document).on('click', '#buttonPostar', function (e) {

        $("#NovaPostagem_Corpo").val($("#NovaPostagem").html());

    });

    $(document).on('click', '.choose-me', function (e) {

        $(e.target).clone().appendTo("#comentario");
        $("#comentario").popover('hide');

    });

    $(document).on('click', '.choose-me-post', function (e) {

        $(e.target).clone().appendTo("#NovaPostagem");
        $("#comentario").popover('hide');

    });

    $(document).on("submit", "form#new_expandable", function (e) {
        e.preventDefault();

        var contents = $(".expandable-input").html();

        $('input#expandable').val(contents);
        this.submit();
    });

    $(document).on('click', '.expand-gif-search', function (e) {

        $("#comentario").popover({

            content: '<input type="text" id="gifsearch" placeholder="Procure um Gif" class= "form-control" /><br/><div class="gif-results"></div>'

        });

        $("#comentario").popover('show');

        $('.popover-dismiss').popover({
            trigger: 'focus'
        });
    });

    $(document).on('click', '.expand-gif-search-comment', function (e) {

        $("#NovaPostagem").popover({

            content: '<input type="text" id="gifsearchPost" placeholder="Procure um Gif" class= "form-control" /><br/><div class="gif-results"></div>'

        });

        $("#NovaPostagem").popover('show');

        $('.popover-dismiss').popover({
            trigger: 'focus'
        });
    });

    $(document).on('click', '.expand-gif-search', function (e) {

        $("#comentario").popover({

            content: '<input type="text" id="gifsearch" placeholder="Procure um Gif" class= "form-control" /><br/><div class="gif-results"></div>'

        });

        $("#comentario").popover('show');

        $('.popover-dismiss').popover({
            trigger: 'focus'
        });
    });

});


function PopulateGifSearchResult(data,IsPost) {

    var searchContent = '<div class="elders-scroll"> <table class="table">';

    for (var i = 0; i < data.length; i++) {

        if (i % 2 === 0) {
            searchContent += '<tr>';
        }

        var imageClass = IsPost ? "choose-me-post" : "choose-me";

        searchContent += '<td><img src="' + data[i].images.downsized_medium.url + '" class="' + imageClass +'" /></td>';

        if (i % 2 !== 0) {
            searchContent += '</tr>';
        }
    }

    searchContent += '</table></div>';

    $(".gif-results").append(searchContent);

}

var span = $('<span>').css('display', 'inline-block')
    .css('word-break', 'break-all')
    .appendTo('body').css('visibility', 'hidden');
function initSpan(textarea) {
    span.text(textarea.text())
        .width(textarea.width())
        .css('font', textarea.css('font'));
}
$('textarea').on({
    input: function () {
        var text = $(this).val();
        span.text(text);
        $(this).height(text ? span.height() : '1.1em');
    },
    focus: function () {
        initSpan($(this));
    },
    keypress: function (e) {
        if (e.which === 13) e.preventDefault();
    }
});
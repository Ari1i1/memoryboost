// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var currentlyFlippedCards = 0;
    var numberOfFlippedCards = 0;
    var currentLevelCardsNumber = $("input[name*='numberOfCards']").val();
    var firstItemAlt = null;
    var secondItemAlt = null;
    var score = 0;

    $('.card').click(function () {
        GameStep(this);
    });

    function GameStep(e) {
        $(e).toggleClass('flipped');
        currentlyFlippedCards += 1;
        numberOfFlippedCards += 1;
        if (currentlyFlippedCards == 1) {
            $(e).addClass('firstFlippedCard');
        }
        if (currentlyFlippedCards == 2) {
            $(e).addClass('secondFlippedCard');
            firstItemAlt = $('.firstFlippedCard').find('img').attr("alt");
            secondItemAlt = $('.secondFlippedCard').find('img').attr("alt");
            $('.card').off('click');
            if (firstItemAlt == secondItemAlt) {
                score += 5;
            }
            else {
                score -= 2;
            }
            jQuery("a[name*='score']").html(`points: ${score}`);
            $("input[name*='score']").val(score);
            $('.firstFlippedCard').removeClass('firstFlippedCard');
            $('.secondFlippedCard').removeClass('secondFlippedCard');
            if (numberOfFlippedCards < currentLevelCardsNumber) {
                currentlyFlippedCards = 0;
                NextStep();
            }
            else {
                $('.card').off('click');
                var gameId = $("input[name*='id']").val();
                $.post("/Games/SaveResults", { id: gameId, score: `${score}` })
            }
        }
    }

    function NextStep() {
        $('.card').click(function () {
            GameStep(this);
        });
    }
});

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var currentlyFlippedCards = 0;
    var numberOfFlippedCards = 0;
    var currentLevelCardsNumber = $('.numberOfCards').val();
    var firstItemCheck = null;
    var secondItemCheck = null;
    var score = 0;

    $('.card').click(function () {
            GameStep(this);
            /*$.get("/Cards/FlipCard", { id: itemId })*/
    });

    function GameStep(e) {
        $(e).toggleClass('flipped');
        currentlyFlippedCards += 1;
        numberOfFlippedCards += 1;
        if (currentlyFlippedCards == 1) {
            $(e).addClass('firstFlippedItem');
            firstItemCheck = $('.firstFlippedCard .itemCheck').val();
        }
        if (currentlyFlippedCards == 2) {
            $(e).addClass('secondFlippedItem');
            secondItemCheck = $('.secondFlippedCard .itemCheck').val();
            $('.card').off('click');
            if (firstItemCheck == secondItemCheck) {
                score += 5;
            }
            else {
                score -= 2;
            }
            jQuery('.score*').html(`points: ${score}`);
            $('.firstFlippedCard').removeClass('firstFlippedCard');
            $('.secondFlippedCard').removeClass('secondFlippedCard');
            if (numberOfFlippedCards < currentLevelCardsNumber) {
                currentlyFlippedCards = 0;
                NextStep();
            }
            else {
                $('.card').off('click');
            }
        }
    }

    function NextStep() {
        $('.card').click(function () {
            GameStep(this);
        });
    }
});

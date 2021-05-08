// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var currentlyFlippedCards = 0;
    var numberOfFlippedCards = 0;
    var currentLevelCardsNumber = $("input[name*='numberOfCards']").val();
    var secForMemorizing = $("input[name*='secForMemorizing']").val();
    var firstItemAlt = null;
    var secondItemAlt = null;
    var score = 0;

    $('.card').addClass('flipped');
    setTimeout(Unflip, secForMemorizing * 1000);
    sec = secForMemorizing;
    var tt = setInterval(Countdown, 998);

    function Countdown() {
        sec--;
        if (sec < 10) {
            $('.timer').html(`time left: 00:00:0${sec}`);
        }
        else {
            $('.timer').html(`time left: 00:00:${sec}`);
        }
    }

    function Unflip() {
        $('.card').removeClass('flipped');
        $('.card').addClass('clickableСard');
        clearInterval(tt);
        InitTimer();
        $('.clickableСard').click(function () {
            GameStep(this);
        });
    }

    function GameStep(e) {
        $(e).addClass('flipped');
        $(e).off('click');
        currentlyFlippedCards += 1;
        numberOfFlippedCards += 1;
        if (currentlyFlippedCards == 1) {
            $(e).addClass('firstFlippedCard');
        }
        if (currentlyFlippedCards == 2) {
            $(e).addClass('secondFlippedCard');
            firstItemAlt = $('.firstFlippedCard').find('img').attr("alt");
            secondItemAlt = $('.secondFlippedCard').find('img').attr("alt");
            $('.clickableСard').off('click');
            if (firstItemAlt == secondItemAlt) {
                score += 5;
                $('.firstFlippedCard').removeClass('clickableСard');
                $('.secondFlippedCard').removeClass('clickableСard');
                $('.firstFlippedCard').removeClass('firstFlippedCard');
                $('.secondFlippedCard').removeClass('secondFlippedCard');
            }
            else {
                score -= 2;
                setTimeout(FlipBack, 1000);
                numberOfFlippedCards -= 2;
            }
            $("a[name*='score']").html(`points: ${score}`);
            $("input[name*='score']").val(score);
            if (numberOfFlippedCards < currentLevelCardsNumber) {
                currentlyFlippedCards = 0;
                NextStep();
            }
            else {
                $('.clickableСard').off('click');
                setTimeout("$('form').submit();", 1000);
            }
        }
    }

    function NextStep() {
        $('.clickableСard').click(function () {
            GameStep(this);
        });
    }
    function FlipBack() {
        $('.firstFlippedCard').removeClass('flipped');
        $('.secondFlippedCard').removeClass('flipped');
        $('.firstFlippedCard').removeClass('firstFlippedCard');
        $('.secondFlippedCard').removeClass('secondFlippedCard');
    }

    min = 0;
    hour = 0;

    function InitTimer() {
        sec = 0;
        setInterval(TimerTick, 1000);
    }

    function TimerTick() {
        sec++;
        if (sec >= 60) { 
            min++;
            sec = sec - 60;
        }
        if (min >= 60) {
            hour++;
            min = min - 60;
        }
        if (sec < 10) { 
            if (min < 10) {
                if (hour < 10) {
                    $('.timer').html(`time: 0${hour}:0${min}:0${sec}`);
                    $("input[name*='timer']").val(`0${hour}:0${min}:0${sec}`);
                } else {
                    $('.timer').html(`time: ${hour}:0${min}:0${sec}`);
                    $("input[name*='timer']").val(`${hour}:0${min}:0${sec}`);
                }
            } else {
                if (hour < 10) {
                    $('.timer').html(`time: 0${hour}:${min}:0${sec}`);
                    $("input[name*='timer']").val(`0${hour}:${min}:0${sec}`);
                } else {
                    $('.timer').html(`time: ${hour}:${min}:0${sec}`);
                    $("input[name*='timer']").val(`${hour}:${min}:0${sec}`);
                }
            }
        } else {
            if (min < 10) {
                if (hour < 10) {
                    $('.timer').html(`time: 0${hour}:0${min}:${sec}`);
                    $("input[name*='timer']").val(`0${hour}:0${min}:${sec}`);
                } else {
                    $('.timer').html(`time: ${hour}:0${min}:${sec}`);
                    $("input[name*='timer']").val(`${hour}:0${min}:${sec}`);
                }
            } else {
                if (hour < 10) {
                    $('.timer').html(`time: 0${hour}:${min}:${sec}`);
                    $("input[name*='timer']").val(`0${hour}:${min}:${sec}`);
                } else {
                    $('.timer').html(`time: ${hour}:${min}:${sec}`);
                    $("input[name*='timer']").val(`${hour}:${min}:${sec}`);
                }
            }
        }
    }

});

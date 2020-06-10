/*global $, $ , window , body, html*/

$(function () {

    'use strict';

    //NiceScroll
    $("body , .main-chat-body-messages").niceScroll({
        cursorcolor: "#3db16b",
        cursorwidth: "7px",
        cursorborder: "1px solid transparent"
    });
    
    // Animate loader off screen 
    $(".se-pre-con").fadeOut("slow");

    // Animate js
    new WOW().init();

});


//Emotions
$(document).ready(function () {
    $("#message-area").emojioneArea({
        search: false,
        tones: false,
        placeholder: "Say Hello!",
        pickerPosition: "top"
    });
});

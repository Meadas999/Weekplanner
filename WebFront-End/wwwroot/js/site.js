﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
new tempusDominus.TempusDominus(document.getElementById('datetimepicker1'));
$(function () {

    // Methode die spacekey weigert.
    $("input#Rspace").on({

        // Bij elke key die wordt ingedrukt.
        keydown: function (e) {

            // 32 = space key
            if (e.which === 32)
                return false;
        },

        // Voor copy/paste injection
        change: function () {
            this.value = this.value.replace(/\s/g, "");
        } 
    });
});
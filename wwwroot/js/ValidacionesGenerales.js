document.addEventListener('DOMContentLoaded', () => {    

    const inputs = document.querySelectorAll('input, textarea');

    inputs.forEach((input) => {
        input.addEventListener('keyup', () => {
            input.value = input.value.toUpperCase();
        });
    });


});
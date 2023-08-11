const minus = document.getElementById("low");
const pilus = document.getElementById("high");
const inputValue = document.getElementById("countInputSmoke");

minus.addEventListener("click", () => {
  if (inputValue.value > 0) {
    inputValue.value = parseInt(inputValue.value) - 1;
  }
});

pilus.addEventListener("click", () => {
  inputValue.value = parseInt(inputValue.value) + 1;
});

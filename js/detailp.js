const minus = document.getElementById("minus");
const pilus = document.getElementById("pilus");
const inputValue = document.getElementById("countInput");

minus.addEventListener("click", () => {
  if (inputValue.value > 0) {
    inputValue.value = parseInt(inputValue.value) - 1;
  }
});

pilus.addEventListener("click", () => {
  inputValue.value = parseInt(inputValue.value) + 1;
});

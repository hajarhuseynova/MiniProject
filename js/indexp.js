const category = document.querySelectorAll(".category");
const cat = document.querySelectorAll(".cat");
const sellests = document.querySelectorAll(".selles");

category.forEach((element) => {
  element.addEventListener("click", (e) => {
    element.classList.toggle("click");
  });
});

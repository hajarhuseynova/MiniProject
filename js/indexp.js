document.addEventListener("DOMContentLoaded", function () {
  const categoryButtons = document.querySelectorAll(".category");
  const sellesItems = document.querySelectorAll(".selles");

  let previousButton = null;

  categoryButtons.forEach((button) => {
    button.addEventListener("click", function () {
      if (previousButton) {
        previousButton.style.backgroundColor = "";
      }

      const filter = button.getAttribute("data-filter");
      button.style.backgroundColor = "black";

      sellesItems.forEach((item) => {
        const category = item.querySelector(".cat").textContent.toLowerCase();
        if (filter === "all" || category === filter) {
          item.style.display = "block";
        } else {
          item.style.display = "none";
        }
      });

      previousButton = button;
    });
  });
});

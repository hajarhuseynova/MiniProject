const open = document.getElementById("burger");
const menu = document.getElementById("menu");
const close = document.getElementById("sidebarDelete");
const visible = document.querySelectorAll(".visible");
const sidebar = document.querySelector(".navbar_bottom");

document.body.addEventListener("click", () => {
  open.classList.remove("displaynone");
  close.classList.add("hideImage");
  visible.forEach((element) => {
    element.classList.add("visible");
  });
  sidebar.classList.add("hideDiv");
});

open.addEventListener("click", (e) => {
  open.classList.toggle("displaynone");
  close.classList.toggle("hideImage");
  visible.forEach((element) => {
    element.classList.toggle("visible");
  });
  sidebar.classList.toggle("hideDiv");
  e.stopPropagation();
});

menu.addEventListener("click", (e) => {
  open.classList.toggle("displaynone");
  close.classList.toggle("hideImage");
  visible.forEach((element) => {
    element.classList.toggle("visible");
  });
  sidebar.classList.toggle("hideDiv");
  e.stopPropagation();
});

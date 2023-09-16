const open = document.getElementById("burger");
const menu = document.getElementById("menu");
const close = document.getElementById("sidebarDelete");
const visible = document.querySelectorAll(".visible");
const sidebar = document.querySelector(".navbar_bottom");

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

const basket = document.querySelector(".basket_header_inner");
const basketItem = document.querySelectorAll(".basketItem");
const basketItems = document.querySelector(".basketItems");

const basketButtons = document.querySelector(".basket_buttons");
const click = document.getElementById("basketclick");

click.addEventListener("click", (e) => {
    basket.classList.toggle("view");
    basketItems.classList.toggle("overflow");
    basketItem.forEach((element) => {
        element.classList.toggle("unvis");
    });
    basketButtons.classList.toggle("gizli");
    e.stopPropagation();
});

document.body.addEventListener("click", () => {
    open.classList.remove("displaynone");
    close.classList.add("hideImage");
    visible.forEach((element) => {
        element.classList.add("visible");
    });
    sidebar.classList.add("hideDiv");

    basket.classList.remove("view");
    basketItems.classList.add("overflow");
    basketItem.forEach((element) => {
        element.classList.add("unvis");
    });
    basketButtons.classList.add("gizli");
});
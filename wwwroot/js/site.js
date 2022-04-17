// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Seleccionar los menus al dar click
function selectMenu(_MenuActivo, _MenuActivoH) {
  
    const Menus =  document.querySelectorAll('.main-sidebar .nav-sidebar > .nav-item');
    
    Menus.forEach(menu => {
      if (menu.id == _MenuActivo){      
        menu.classList.add("menu-open");
        menu.querySelector('.nav-link').classList.add('active');      
        menu.querySelectorAll('.nav > .nav-item').forEach(submenu => {
          if(submenu.id == _MenuActivoH){
            submenu.querySelector('.nav-link').classList.add('active');
          } else {
            submenu.querySelector('.nav-link').classList.remove('active');
          }
        });
      } else {      
        menu.classList.remove('menu-open');
        menu.querySelector('.nav-link').classList.remove('active');      
        menu.querySelectorAll('.nav > .nav-item').forEach(submenu => {
          submenu.querySelector('a').classList.remove('active');
        });
      }
    });
  };
  
  document.addEventListener('DOMContentLoaded', () => {   
    
    const BTheme = document.getElementById('BTheme');
    const BThemeIcon = document.getElementById('BThemeIcon');  
    const mSidebar = document.getElementById('MainSidebar');
  
    if(localStorage.getItem('Theme') == 'dark'){
      document.body.classList.add('dark-mode');
      mSidebar.classList.remove('sidebar-light-orange');
      mSidebar.classList.add('sidebar-dark-orange');
      if(BTheme != null){
        BThemeIcon.classList.remove('fa-moon');
        BThemeIcon.classList.add('fa-sun');
      }    
    }
  
    if(BTheme != null){
      BTheme.addEventListener('click', () =>{    
        document.body.classList.toggle('dark-mode');
        
        if(BThemeIcon.classList.contains('fa-moon')){
          BThemeIcon.classList.remove('fa-moon');
          BThemeIcon.classList.add('fa-sun');
          localStorage.setItem('Theme', 'dark');   
        } else {      
          BThemeIcon.classList.remove('fa-sun');
          BThemeIcon.classList.add('fa-moon');
          localStorage.setItem('Theme', 'light');
        }

        if(mSidebar.classList.contains('sidebar-light-orange')){
            mSidebar.classList.remove('sidebar-light-orange');
            mSidebar.classList.add('sidebar-dark-orange');
        }else{
            mSidebar.classList.remove('sidebar-dark-orange');
            mSidebar.classList.add('sidebar-light-orange');            
        }
      });
    }
  
    const MenuActivo = document.getElementById('MenuActivo');
    const MenuActivoH = document.getElementById('MenuActivoH');
    
    if(MenuActivo != null ){
      selectMenu(MenuActivo.value, MenuActivoH.value);
    }
  
  });
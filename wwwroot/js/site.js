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


const fillChildCombo = function (Combo, Url, Param = {}, Hijo = false) {
  
  if (Param !== null) {
      Object.entries(Param).forEach(function (entry, index) {            
          Url = Url + (index === 0 ? '?' : '&');
          const [key, value] = entry;
          Url = `${Url}${key}=${value}`;
      });
  }
  
  Combo.querySelectorAll('option').forEach(option => option.remove());

  getJsonData(Url).then(result => {
      if (result.success !== false) {
          result.forEach(function (item) {
              const option = document.createElement('option');
              option.value = item.value;
              option.text = item.text;
              Combo.appendChild(option);
          });

          if (Hijo) {                
              Combo.dispatchEvent(new Event('change'));
          }
          
          return;
      }
      MensajeAlerta(result.responseTitulo, result.responseMensaje, result.responseIcon);
      console.log(result.responseMensaje);
  });    
};

const MensajeAlerta = function(titulo, mensaje, icono){
  Swal.fire({
    title: titulo,
    text: decodeHTMLEntities(mensaje),
    icon: icono
  });
};


const MensajeConfirmacion = function(titulo, mensaje, icono, href) {
  Swal.fire({
    title: titulo,
    text: mensaje,
    icon: icono,
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Si, borralo!'
  }).then((result) => {
    if (result.isConfirmed) {
      window.location = href;
    }
  })
};




const getJsonData = async function (url = '') {
  const response = await fetch(url);
  return response.json();
};

function decodeHTMLEntities(text) {
  var textArea = document.createElement('textarea');
  textArea.innerHTML = text;
  return textArea.value;
}

function encodeHTMLEntities(text) {
  var textArea = document.createElement('textarea');
  textArea.innerText = text;
  return textArea.innerHTML;
}

  
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

  $('[data-toggle="tooltip"]').tooltip();

});
(() => {
  const button=document.createElement('button');button.type='button';button.className='button secondary';button.textContent='Crop & adjust photo';button.disabled=!photo;$('#cameraMessage').before(button);
  const dialog=document.createElement('dialog');dialog.className='photo-editor';dialog.setAttribute('aria-labelledby','photoEditorTitle');
  dialog.innerHTML=`<h2 id="photoEditorTitle">Crop & adjust photo</h2><p>Drag on the image to select a crop. Adjustments stay in this editor until you save.</p><div class="photo-editor-tools"><button type="button" data-action="left">Rotate left</button><button type="button" data-action="right">Rotate right</button><button type="button" data-action="flip">Flip horizontal</button><button type="button" data-action="crop">Apply crop</button><button type="button" data-action="undo">Undo</button><button type="button" data-action="reset">Reset original</button></div><canvas aria-label="Photo crop selection"></canvas><div class="photo-adjustments"></div><p class="photo-editor-status" role="status"></p><div class="photo-editor-tools"><button type="button" data-action="cancel">Cancel</button><button type="button" data-action="save">Save photo</button></div>`;
  document.body.append(dialog);
  const style=document.createElement('style');style.textContent='.photo-editor{width:min(920px,94vw);max-height:92vh;overflow:auto;border:1px solid #ddd;border-radius:16px;padding:24px;color:#263238}.photo-editor::backdrop{background:#0008}.photo-editor canvas{display:block;max-width:100%;max-height:48vh;width:auto;height:auto;margin:16px auto;touch-action:none;cursor:crosshair}.photo-editor-tools{display:flex;gap:8px;flex-wrap:wrap}.photo-editor button{padding:10px 16px;border:1px solid #d5c8c8;border-radius:6px;background:#fff;color:#852b2b;cursor:pointer}.photo-editor button:disabled{opacity:.4;cursor:default}.photo-editor [data-action=save]{background:#ac292e;color:white}.photo-adjustments{display:grid;grid-template-columns:repeat(auto-fit,minmax(150px,1fr));gap:14px}.photo-adjustments label{display:flex;flex-direction:column;gap:6px}.photo-adjustments input{width:100%}';document.head.append(style);
  const view=dialog.querySelector('canvas'),ctx=view.getContext('2d'),status=dialog.querySelector('[role=status]');
  const controls={},defaults={brightness:100,contrast:100,saturation:100};
  for(const [key,label] of Object.entries({brightness:'Brightness',contrast:'Contrast',saturation:'Colour saturation'})){
    const el=document.createElement('label');el.textContent=label;const output=document.createElement('output'),input=document.createElement('input');input.type='range';input.min=0;input.max=200;input.value=100;input.setAttribute('aria-label',label);el.append(output,input);dialog.querySelector('.photo-adjustments').append(el);controls[key]={input,output};input.oninput=draw;
  }
  let original=photo,base=null,selection=null,start=null,history=[],editingPhoto='',revision=0;
  const nativeSetPhoto=setPhoto;
  setPhoto=function(data){original=data;revision++;if(dialog.open)dialog.close();nativeSetPhoto(data);button.disabled=!data;};
  form.addEventListener('reset',()=>{original='';revision++;button.disabled=true;dialog.close();});
  const make=(w,h)=>{const c=document.createElement('canvas');c.width=w;c.height=h;return c;};
  function settings(){return Object.fromEntries(Object.entries(controls).map(([k,v])=>[k,Number(v.input.value)]));}
  function assign(values){for(const key in controls)controls[key].input.value=values[key];}
  function remember(){const c=make(base.width,base.height);c.getContext('2d').drawImage(base,0,0);history.push({base:c,values:settings()});if(history.length>6)history.shift();}
  function render(){const c=make(base.width,base.height),p=c.getContext('2d'),s=settings();p.filter=`brightness(${s.brightness}%) contrast(${s.contrast}%) saturate(${s.saturation}%)`;p.drawImage(base,0,0);return c;}
  function draw(){if(!base)return;view.width=base.width;view.height=base.height;ctx.drawImage(render(),0,0);if(selection){ctx.strokeStyle='#e22';ctx.lineWidth=Math.max(2,base.width/350);ctx.setLineDash([12,8]);ctx.strokeRect(...selection);ctx.setLineDash([]);}for(const key in controls)controls[key].output.textContent=controls[key].input.value+'%';dialog.querySelector('[data-action=undo]').disabled=!history.length;dialog.querySelector('[data-action=crop]').disabled=!selection;status.textContent=`${base.width} × ${base.height} pixels`;}
  async function load(data){const img=new Image();img.src=data;await img.decode();const c=make(img.naturalWidth,img.naturalHeight);c.getContext('2d').drawImage(img,0,0);return c;}
  button.onclick=async()=>{if(!photo)return;const token=revision;editingPhoto=photo;try{const loaded=await load(photo);if(token!==revision)return;stopCamera();base=loaded;history=[];selection=null;assign(defaults);draw();dialog.showModal();}catch{notify('Unable to open this photo.');}};
  for(const control of Object.values(controls)){control.input.addEventListener('pointerdown',()=>remember());control.input.addEventListener('keydown',e=>{if(['ArrowLeft','ArrowRight','Home','End','PageUp','PageDown'].includes(e.key))remember();});}
  function position(e){const r=view.getBoundingClientRect();return [Math.max(0,Math.min(view.width,(e.clientX-r.left)*view.width/r.width)),Math.max(0,Math.min(view.height,(e.clientY-r.top)*view.height/r.height))];}
  view.onpointerdown=e=>{start=position(e);view.setPointerCapture(e.pointerId);};view.onpointermove=e=>{if(!start)return;const p=position(e);selection=[Math.min(start[0],p[0]),Math.min(start[1],p[1]),Math.abs(p[0]-start[0]),Math.abs(p[1]-start[1])];draw();};view.onpointerup=()=>{start=null;};view.onpointercancel=()=>{start=null;selection=null;draw();};
  dialog.addEventListener('click',async e=>{const action=e.target.dataset.action;if(!action)return;
    if(action==='cancel'){dialog.close();return;}
    if(action==='save'){if(photo!==editingPhoto){dialog.close();return notify('Photo changed. Reopen the editor.');}nativeSetPhoto(render().toDataURL('image/jpeg',.9));revision++;$('#cameraMessage').textContent='Photo adjustments saved. Ready for registration.';dialog.close();return;}
    if(action==='undo'){const previous=history.pop();if(previous){base=previous.base;assign(previous.values);selection=null;draw();}return;}
    if(action==='reset'){const token=revision;try{const restored=await load(original);if(token!==revision||!dialog.open)return;remember();base=restored;assign(defaults);selection=null;draw();}catch{status.textContent='Unable to restore the original.';}return;}
    if(action==='crop'){if(!selection)return;const [x,y,w,h]=selection.map(Math.round);if(w<50||h<50){status.textContent='Select at least 50 × 50 pixels.';return;}remember();const c=make(w,h);c.getContext('2d').drawImage(base,x,y,w,h,0,0,w,h);base=c;}
    if(['left','right','flip'].includes(action)){remember();const flip=action==='flip',c=make(flip?base.width:base.height,flip?base.height:base.width),p=c.getContext('2d');p.translate(c.width/2,c.height/2);if(flip)p.scale(-1,1);else p.rotate((action==='left'?-1:1)*Math.PI/2);p.drawImage(base,-base.width/2,-base.height/2);base=c;}
    selection=null;draw();
  });
})();

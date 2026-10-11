(() => {
  const sides = {front: null, back: null};
  let busy = false, request, generation = 0;
  const title = s => s[0].toUpperCase() + s.slice(1);
  function changed() { generation++; $('#ocrReview')?.remove(); dirty = true; clearSignature(); $('#ocrDetails').hidden = true; $('#ocrText').textContent = ''; }
  function render() {
    for (const side of ['front','back']) {
      const item = sides[side];
      $(`#${side}Preview`).hidden = !item;
      if (item) $(`#${side}Preview`).src = item.image; else $(`#${side}Preview`).removeAttribute('src');
      $(`#${side}Placeholder`).hidden = !!item;
      $(`#${side}State`).textContent = item ? 'Captured ✓' : 'Required';
      $(`#edit${title(side)}`).disabled = !item || busy;
      $(`#scan${title(side)}`).disabled = busy;
      $(`#scan${title(side)}`).textContent = item ? `Rescan ${side}` : `Scan ${side}`;
      $(`#upload${title(side)}`).disabled = busy;
    }
    const count = Object.values(sides).filter(Boolean).length;
    $('#scanCount').textContent = `${count} of 2 sides captured`;
    $('#extract').disabled = count === 0 || busy;
    $('#refreshScanner').disabled = busy;
  }
  async function normalize(src) {
    const img = new Image(); img.src = src; await img.decode();
    const scale = Math.min(1,2400 / Math.max(img.naturalWidth,img.naturalHeight));
    const c = document.createElement('canvas'); c.width=Math.round(img.naturalWidth*scale); c.height=Math.round(img.naturalHeight*scale);
    c.getContext('2d').drawImage(img,0,0,c.width,c.height);
    return c.toDataURL('image/jpeg',.94);
  }
  async function put(side,src) { const data=await normalize(src); sides[side]={image:data,original:data}; changed(); render(); $('#scanProgress').textContent=side==='front'&&!sides.back?'Front captured. Flip and reinsert the ID, then scan the back.':'Image captured. Crop or rotate it if needed.'; }
  async function status() {
    if (busy) return; busy=true; render(); $('#scannerStatus').textContent='Checking fi-800R…';
    try { const result=await api('/api/scanner/status'); $('#scannerStatus').textContent=result.message; $('#scannerFooter').textContent='fi-800R connected'; }
    catch(error) { $('#scannerStatus').textContent=error.message; $('#scannerFooter').textContent='Scanner unavailable'; }
    finally { busy=false; render(); }
  }
  for (const side of ['front','back']) {
    $(`#scan${title(side)}`).onclick=async()=>{
      if(busy)return; busy=true;render();request=new AbortController();$('#cancelScan').hidden=false;
      $('#scanProgress').textContent=`Scanning ${side}… Keep the document in the feeder.`;
      try { const result=await api('/api/scanner/scan',{method:'POST',signal:request.signal}); await put(side,result.image); $('#scannerStatus').textContent=result.source+' · connected'; }
      catch(error) { $('#scanProgress').textContent=error.name==='AbortError'?'Scan cancelled. Check the feeder before retrying.':error.message; }
      finally { request=null;busy=false;$('#cancelScan').hidden=true;render(); }
    };
    $(`#upload${title(side)}`).onchange=async e=>{
      const file=e.target.files[0]; if(!file)return;
      if(!['image/jpeg','image/png'].includes(file.type)||file.size>8*1024*1024){notify('Choose a JPG or PNG under 8 MB.');return;}
      busy=true;render();const url=URL.createObjectURL(file);
      try{await put(side,url);}catch{notify('That image could not be opened. Try another file.');}finally{URL.revokeObjectURL(url);e.target.value='';busy=false;render();}
    };
    $(`#edit${title(side)}`).onclick=()=>openEditor(side);
  }
  $('#refreshScanner').onclick=status;
  $('#cancelScan').onclick=()=>request?.abort();
  $('#extract').onclick=async()=>{
    const captured=['front','back'].filter(side=>sides[side]);
    if(busy||!captured.length)return;
    busy=true;render();request=new AbortController();$('#cancelScan').hidden=false;
    $('#extract').textContent='Extracting…';$('#ocrReview')?.remove();
    $('#ocrDetails').hidden=true;$('#ocrMessage').textContent='Reading captured sides locally…';
    const run=++generation,results=[],failures=[];
    try {
      for(const side of captured){
        $('#scanProgress').textContent=`Extracting ${side}…`;
        const body=new FormData();const bytes=Uint8Array.from(atob(sides[side].image.split(',')[1]),c=>c.charCodeAt(0));
        body.append('document',new Blob([bytes],{type:'image/jpeg'}),side+'.jpg');
        try{const result=await api('/api/extract',{method:'POST',body,signal:request.signal});if(run!==generation)return;results.push({side,...result});}
        catch(error){if(error.name==='AbortError')throw error;failures.push(`${title(side)}: ${error.message}`);}
      }
      if(run!==generation)return;
      $('#ocrDetails').hidden=!results.length;
      $('#ocrText').textContent=results.map(r=>`${title(r.side)}
${r.text}`).join('\n\n');
      const labels={name:'Full name',idNumber:'ID / passport number',nationality:'Nationality',dob:'Date of birth',expiry:'Document expiry'};
      const candidates={};
      for(const result of results)for(const [key,value]of Object.entries(result.fields)){
        if(!labels[key]||!value)continue;
        (candidates[key]??=[]).push({value,side:result.side});
      }
      const panel=document.createElement('section');panel.id='ocrReview';panel.className='ocr-review';
      const heading=document.createElement('h3');heading.textContent='Review extracted details';
      const help=document.createElement('p');help.textContent='Check each value against the scan. Select the fields to apply; existing entries are left unchecked. You can correct a value before applying it.';
      panel.append(heading,help);const rows=[];
      for(const [key,items]of Object.entries(candidates)){
        const unique=[...new Set(items.map(item=>item.value))];
        const row=document.createElement('div');row.className='ocr-review-row';
        const label=document.createElement('label'),check=document.createElement('input');check.type='checkbox';
        const current=form.elements[key].value;check.checked=!current&&unique.length===1;
        label.append(check,document.createTextNode(` Apply ${labels[key]}`));
        const input=document.createElement('input');input.type=['dob','expiry'].includes(key)?'date':'text';input.maxLength=200;
        input.setAttribute('aria-label',`Extracted ${labels[key]}`);input.value=unique.length===1?unique[0]:'';
        input.oninput=()=>check.checked=!!input.value;
        const note=document.createElement('small');note.textContent=`Current: ${current||'empty'}. `+items.map(item=>`${title(item.side)}: ${item.value}`).join(' · ');
        if(unique.length>1){const conflict=document.createElement('strong');conflict.textContent='Sides disagree — enter the correct value.';row.append(conflict);}
        row.append(label,input,note);panel.append(row);rows.push({key,input,check,current});
      }
      if(rows.length){
        const apply=document.createElement('button');apply.type='button';apply.className='button primary';apply.textContent='Apply selected details';
        apply.onclick=()=>{
          if(run!==generation)return;
          const chosen=rows.filter(row=>row.check.checked);
          if(!chosen.length)return notify('Select at least one field to apply.');
          if(chosen.some(row=>form.elements[row.key].value!==row.current))return notify('Registration details changed after extraction. Extract again before applying these results.');
          for(const row of chosen)if(!row.input.value.trim()||!row.input.checkValidity()){row.input.reportValidity();return notify('Enter a valid value for each selected field.');}
          for(const row of chosen)form.elements[row.key].value=row.input.value.trim();
          changed();$('#ocrMessage').textContent=`${chosen.length} reviewed fields applied. Continue to Verify/New to check the registration.`;
        };panel.append(apply);$('#ocrDetails').before(panel);
      }
      const low=results.some(result=>result.confidence<.65);
      $('#ocrMessage').textContent=(rows.length?'Extraction complete. Review the suggested fields below.':'No supported identity fields found. Try a tighter crop, rotate the scan or enter the details in Verify/New.')+(low?' Text recognition quality is low; inspect every value carefully.':'')+(failures.length?' '+failures.join(' '):'');
      $('#scanProgress').textContent='OCR finished. The original scans are unchanged.';
    }catch(error){if(run===generation)$('#ocrMessage').textContent=error.name==='AbortError'?'OCR cancelled. No registration fields were changed.':error.message;}
    finally{busy=false;request=null;$('#cancelScan').hidden=true;render();$('#extract').textContent='Extract identity details';}
  };
  window.scanDocuments={
    complete:()=>!busy&&!!sides.front&&!!sides.back,
    values:()=>({documentFront:sides.front?.image||'',documentBack:sides.back?.image||''}),
    reset:()=>{generation++;request?.abort();$('#ocrReview')?.remove();sides.front=sides.back=null;render();$('#ocrDetails').hidden=true;$('#ocrText').textContent='';$('#scanProgress').textContent='Insert the ID front side, then select Scan front.';$('#ocrMessage').textContent='Local OCR is ready. Capture or upload a side, then extract and review the identity details.';}
  };
  // Edits stay in this modal until Save. The captured original is always retained for reset.
  const dialog=$('#scanEditor'), view=$('#cropCanvas'), ctx=view.getContext('2d');
  let editing, working, undo=[], dragStart=null;
  const cropIds=['cropX','cropY','cropW','cropH'];
  function selection(){return cropIds.map(id=>Number($('#'+id).value));}
  function clearCrop(){[0,0,100,100].forEach((n,i)=>$('#'+cropIds[i]).value=n);}
  async function draw(){const img=new Image();img.src=working;await img.decode();view.width=img.naturalWidth;view.height=img.naturalHeight;ctx.drawImage(img,0,0);const [x,y,w,h]=selection();ctx.strokeStyle='#a52a2a';ctx.lineWidth=Math.max(view.width/350,2);ctx.setLineDash([view.width/80,view.width/120]);ctx.strokeRect(x*view.width/100,y*view.height/100,w*view.width/100,h*view.height/100);$('#imageDimensions').textContent=`${view.width} × ${view.height} px`;$('#undoEdit').disabled=!undo.length;}
  async function openEditor(side){editing=side;working=sides[side].image;undo=[];clearCrop();$('#editorTitle').textContent=`Edit ${side} scan`;await draw();dialog.showModal();}
  function remember(){undo.push(working);if(undo.length>8)undo.shift();}
  async function rotate(direction){const img=new Image();img.src=working;await img.decode();const c=document.createElement('canvas');c.width=img.height;c.height=img.width;const p=c.getContext('2d');p.translate(c.width/2,c.height/2);p.rotate(direction*Math.PI/2);p.drawImage(img,-img.width/2,-img.height/2);remember();working=c.toDataURL('image/jpeg',.94);clearCrop();await draw();}
  $('#rotateLeft').onclick=()=>rotate(-1);$('#rotateRight').onclick=()=>rotate(1);
  $('#undoEdit').onclick=()=>{if(undo.length){working=undo.pop();clearCrop();draw();}};
  $('#resetEdit').onclick=()=>{remember();working=sides[editing].original;clearCrop();draw();};
  $('#closeEditor').onclick=()=>dialog.close();
  $('#saveEdit').onclick=()=>{sides[editing].image=working;changed();render();dialog.close();};
  cropIds.forEach(id=>$('#'+id).oninput=draw);
  function position(e){const r=view.getBoundingClientRect();return [Math.min(100,Math.max(0,(e.clientX-r.left)*100/r.width)),Math.min(100,Math.max(0,(e.clientY-r.top)*100/r.height))];}
  view.onpointerdown=e=>{dragStart=position(e);view.setPointerCapture(e.pointerId);};
  view.onpointermove=e=>{if(!dragStart)return;const p=position(e);const numbers=[Math.min(p[0],dragStart[0]),Math.min(p[1],dragStart[1]),Math.abs(p[0]-dragStart[0]),Math.abs(p[1]-dragStart[1])];numbers.forEach((n,i)=>$('#'+cropIds[i]).value=n.toFixed(1));draw();};
  view.onpointerup=view.onpointercancel=()=>dragStart=null;
  $('#applyCrop').onclick=async()=>{const [x,y,w,h]=selection();if(![x,y,w,h].every(Number.isFinite)||x<0||y<0||w<=0||h<=0||x+w>100.1||y+h>100.1)return notify('Choose a crop area within the image.');const img=new Image();img.src=working;await img.decode();const c=document.createElement('canvas');c.width=Math.round(w*img.width/100);c.height=Math.round(h*img.height/100);if(c.width<50||c.height<50)return notify('Crop must be at least 50 × 50 pixels.');c.getContext('2d').drawImage(img,x*img.width/100,y*img.height/100,c.width,c.height,0,0,c.width,c.height);remember();working=c.toDataURL('image/jpeg',.94);clearCrop();draw();};
  status();
})();

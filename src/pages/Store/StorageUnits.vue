<template>
  <q-page padding>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Единицы хранения</h6>
          <q-btn @click="addStorageUnit = true" size="sm" color="secondary" :icon="icons.mdiPencil" label="единицу" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="fullName" :props="props">
            {{ props.row.fullName }}
            <q-popup-edit
              v-model="props.row.fullName"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.fullName" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="code" :props="props">
            {{ props.row.code }}
            <q-popup-edit
              v-model="props.row.code"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.code" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="internationalAbbreviation" :props="props">
            {{ props.row.internationalAbbreviation }}
            <q-popup-edit
              v-model="props.row.internationalAbbreviation"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.internationalAbbreviation" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="measuredValueType" :props="props">
            {{ props.row.measuredValueType }}
            <q-popup-edit
              v-model="props.row.measuredValueType"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-select filled v-model="props.row.measuredValueType" :options="measuredValueTypes" label="Filled" />
            </q-popup-edit>
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.unitId)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addStorageUnit" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Создать единицу хранения.</span>
        </q-card-section>

        <CreateStorageUnitPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

  </q-page>
</template>

<script>
import icons from 'src/mixins/icons'
import CreateStorageUnitPopup from 'components/creationElements/CreateStorageUnitPopup'
export default {
  components: { CreateStorageUnitPopup },
  mixins: [icons],
  methods: {
    saveChanges (unitId) {
    }
  },
  data: () => {
    return {
      loading: false,
      addStorageUnit: false,
      data: [],
      measuredValueTypes: ['type', 'type2'],
      columns: [
        { name: 'name', label: 'Название', align: 'left', field: 'name' },
        { name: 'fullName', label: 'Полное название', field: 'fullName' },
        { name: 'code', label: 'Код', field: 'code' },
        { name: 'internationalAbbreviation', label: 'Международная аббревиатура', field: 'internationalAbbreviation' },
        { name: 'measuredValueType', label: 'Measured Value Type', field: 'measuredValueType' },
        { name: 'actions', label: '', field: 'actions' }
      ]
    }
  }
}
</script>

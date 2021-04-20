<template>
  <q-page padding>
    <q-table
      title="Должности"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
    >
      <template v-slot:top>
        <div class="flex flex-center justify-between" style="width: 100%">
          <h6 class="q-ma-none">Должности</h6>
          <q-btn class="q-ml-sm" :icon="mdiPlus" color="secondary" size="sm" label="должность" @click="position = true" :loading="loading" />
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
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="description" :props="props">
            {{ props.row.description }}
            <q-popup-edit
              v-model="props.row.description"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.description" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="includeAt" :props="props">
            {{ props.row.includeAt }}
            <q-popup-edit
              v-model="props.row.includeAt"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.includeAt" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="excludeAt" :props="props">
            {{ props.row.excludeAt }}
            <q-popup-edit
              v-model="props.row.excludeAt"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.excludeAt" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="status" :props="props">
            {{ props.row.excludeAt === null ? 'valid' : 'invalid' }}
          </q-td>
          <q-td key="saveChanges" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.name)" :loading="loading" />
            <q-btn class="q-ml-sm" color="purple" size="sm" label="Изменить статус" @click="changeStatus(props.row.name)" :loading="loading" />
          </q-td>
        </q-tr>

        <q-dialog v-model="position" persistent>
          <q-card style="width: 500px">
            <q-card-section class="row items-center justify-between">
              <span class="q-ml-sm">Добавить Должность.</span>
            </q-card-section>

            <CreatePositionPopup />

            <q-card-actions align="right">
              <q-btn flat label="Закрыть" color="primary" v-close-popup />
              <q-btn flat label="Добавить" color="primary" v-close-popup />
            </q-card-actions>
          </q-card>
        </q-dialog>

      </template>
    </q-table>
  </q-page>
</template>

<script>
import { mdiPlus } from '@quasar/extras/mdi-v5'
import CreatePositionPopup from 'components/creationElements/CreatePositionPopup'
export default {
  name: 'PageCompanyAll',
  methods: {
    changeStatus (id) {
    },
    saveChanges (id) {
    }
  },
  components: {
    CreatePositionPopup
  },
  data: () => {
    return {
      loading: false,
      mdiPlus,
      position: false,
      data: [
        { name: 'JJJJddfdf', description: 'DFGA', includeAt: '25.03.2000', excludeAt: '25.03.2020', saveChanges: '' },
        { name: 'JJJJddfdf', description: 'DFGA', includeAt: '25.03.2000', excludeAt: '25.03.2020', saveChanges: '' }
      ],
      columns: [
        {
          name: 'name',
          label: 'Название',
          align: 'left',
          field: 'name'
        },
        { name: 'description', label: 'Описание', field: 'description' },
        { name: 'includeAt', label: 'Создана', field: 'includeAt' },
        { name: 'excludeAt', label: 'Отменена', field: 'excludeAt' },
        { name: 'status', label: 'Статус', field: 'status' },
        { name: 'saveChanges', label: '', field: 'saveChanges' }
      ]
    }
  }
}
</script>
